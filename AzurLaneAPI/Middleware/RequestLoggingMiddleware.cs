using System.Threading.Tasks;
using AzurLaneClasses;
using Microsoft.AspNetCore.Http;
using Newtonsoft.Json;

namespace AzurLaneAPI.Middleware
{
	public class RequestLoggingMiddleware
	{
		private readonly RequestDelegate _next;
		private AzurLaneDbContext _context;

		public RequestLoggingMiddleware(RequestDelegate next)
		{
			_next = next;
			_context = new AzurLaneDbContext();
		}

		public async Task Invoke(HttpContext context)
		{
			try
			{
				await _next(context);
			}
			finally
			{
				RequestLog log = new RequestLog();
				log.Method = context.Request?.Method;
				log.Path = context.Request?.Path;
				log.QueryString = JsonConvert.SerializeObject(context.Request?.Query, Formatting.Indented);
				log.Protocol = context.Request?.Protocol;
				log.ContentType = context.Request?.ContentType;
				log.ResonseStatusCode = context.Response.StatusCode.ToString();

				if (context.Request.Headers.ContainsKey("Authorization"))
				{
					log.AppliedToken = context.Request.Headers["Authorization"];
				}

				await _context.RequestLogs.AddAsync(log);
				await _context.SaveChangesAsync();
			}
		}
	}
}
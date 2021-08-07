using System.Threading.Tasks;
using AzurLaneClasses;
using Microsoft.AspNetCore.Http;
using Newtonsoft.Json;

namespace AzurLaneAPI.Middleware
{
	public class RequestLoggingMiddleware
	{
		private readonly RequestDelegate _next;

		public RequestLoggingMiddleware(RequestDelegate next)
		{
			_next = next;
		}

		public async Task Invoke(HttpContext context)
		{
			try
			{
				await _next(context);
			}
			finally
			{
				AzurLaneDbContext ctx = new AzurLaneDbContext();
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

				await ctx.RequestLogs.AddAsync(log);
				await ctx.SaveChangesAsync();
			}
		}
	}
}
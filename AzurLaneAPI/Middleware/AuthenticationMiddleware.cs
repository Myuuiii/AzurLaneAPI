using System;
using System.Linq;
using System.Threading.Tasks;
using AzurLaneClasses;
using Microsoft.AspNetCore.Http;

namespace AzurLaneAPI.Middleware
{
    public class AuthenticationMiddleware
    {
        private readonly RequestDelegate _next;

        public AuthenticationMiddleware(RequestDelegate next)
        {
            _next = next;
        }

        public async Task InvokeAsync(HttpContext context)
        {
            System.Console.WriteLine(context.Request.Path.Value);
            if (context.Request.Path.Value.Contains("swagger"))
            {
                await _next(context);
            }
            else
            {
                if (context.Request.Headers.ContainsKey("Authorization"))
                {
                    AzurLaneDbContext ctx = new AzurLaneDbContext();
                    string rawToken = context.Request.Headers["Authorization"].ToString().Replace("Bearer ", null);

                    if (ctx.ALTokens.Any(u => u.Token == rawToken))
                    {
                        ALToken token = ctx.ALTokens.Single(u => u.Token == rawToken);
                        if (token.Active)
                        {
                            await _next(context);
                        }
                        else
                        {
                            context.Response.StatusCode = 403;
                            return;
                        }
                    }
                    else { context.Response.StatusCode = 401; return; }
                }
                else { context.Response.StatusCode = 401; return; }
            }
        }
    }
}
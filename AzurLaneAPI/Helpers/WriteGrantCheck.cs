using System;
using System.Linq;
using AzurLaneClasses;
using Microsoft.AspNetCore.Http;

namespace AzurLaneAPI.Helpers
{
    public class WriteGrantCheck
    {
        public static void Check(HttpContext context)
        {
            AzurLaneDbContext ctx = new AzurLaneDbContext();
            string rawToken = context.Request.Headers["Authorization"].ToString().Replace("Bearer ", null);
            ALToken token = ctx.ALTokens.Single(t => t.Token == rawToken);
            if (!token.WriteGrant)
            {
                context.Response.StatusCode = 403;
                context.Response.CompleteAsync();
            }
        }
    }
}
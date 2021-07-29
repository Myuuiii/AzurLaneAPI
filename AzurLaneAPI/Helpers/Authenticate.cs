using System;
using System.Linq;
using System.Net;
using System.Net.Http;
using AzurLaneClasses;
using Microsoft.AspNetCore.Http;

namespace AzurLaneAPI
{
    public partial class Helpers
    {
        /// <summary>
        /// Check if the request is authenticated
        /// </summary>
        public static Boolean Authenticate(HttpContext context)
        {
            AzurLaneDbContext ctx = new AzurLaneDbContext();

            // Save the value of the Authorization header in a variable

            if (context.Request.Headers.ContainsKey("Authorization"))
            {
                String authHeader = context.Request.Headers["Authorization"];
                String[] authHeaderParts = authHeader.Split(' ');
                String token = String.Join(' ', authHeaderParts.Skip(1));

                if (ctx.ALTokens.Any(t => t.Token == token))
                {
                    ALToken authToken = ctx.ALTokens.Single(t => t.Token == token);
                    if (authToken.Active)
                    {
                        authToken.LastRequest = DateTime.Now;
                        ctx.SaveChanges();
                        return true;
                    }
                    else
                    {
                        return false;
                    }
                }
                else
                {
                    return false;
                }
            }
            else 
            {
                return false;
            }
        }
    }
}
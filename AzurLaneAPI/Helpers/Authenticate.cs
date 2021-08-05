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
        private static AzurLaneDbContext _context;

		public Helpers(AzurLaneDbContext context)
		{
			_context = new AzurLaneDbContext();
		}

		/// <summary>
		/// Check if the request is authenticated
		/// </summary>
		public static Boolean Authenticate(HttpContext context)
        {
            // Save the value of the Authorization header in a variable
            _context = new AzurLaneDbContext();
            if (context.Request.Headers.ContainsKey("Authorization"))
            {
                String authHeader = context.Request.Headers["Authorization"];
                String[] authHeaderParts = authHeader.Split(' ');
                String token = String.Join(' ', authHeaderParts.Skip(1));

                if (_context.ALTokens.Any(t => t.Token == token))
                {
                    ALToken authToken = _context.ALTokens.Single(t => t.Token == token);
                    if (authToken.Active)
                    {
                        authToken.LastRequest = DateTime.Now;
                        _context.SaveChanges();
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
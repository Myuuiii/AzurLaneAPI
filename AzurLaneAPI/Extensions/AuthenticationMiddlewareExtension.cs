using AzurLaneAPI.Middleware;
using Microsoft.AspNetCore.Builder;

namespace AzurLaneAPI.Extensions
{
    public static class AuthenticationMiddlewareExtension
    {
        public static IApplicationBuilder UseAuthenticationMiddleware(this IApplicationBuilder builder)
        {
            return builder.UseMiddleware<AuthenticationMiddleware>();
        }
    }
}
using Azure.Core;
using Microsoft.Extensions.Caching.Memory;
using System.Net;

namespace EcomProject.Middleware
{
    public class ExceptionMiddleware
    {
        private readonly IMemoryCache memoryCache;
        private readonly TimeSpan rateLimitWindow= TimeSpan.FromSeconds(30);
        private readonly RequestDelegate _next;
        public ExceptionMiddleware(IMemoryCache memoryCache,RequestDelegate next)
        {
            this.memoryCache = memoryCache;
            _next = next;
        }

        public async Task InvokeAsync(HttpContext context)
        {
            try
            {
                ApplySecurity(context);
                if (isRequestAllowed(context) == false) 
                {
                    context.Response.StatusCode = (int)HttpStatusCode.TooManyRequests;
                    context.Response.ContentType = "application/json";

                    var response = new
                    {
                        statusCode = context.Response.StatusCode,
                        Message = "Too many request, try again later"
                    };
                    await context.Response.WriteAsJsonAsync(response);

                    await _next(context);

                }
            }  
            catch (Exception ex) {
                throw new Exception(ex.Message);
            }
        }
        private bool isRequestAllowed(HttpContext context)
        {
            var ip =context.Connection.RemoteIpAddress.ToString();
            var cacheKey = $"Rate:{ip}";

            var dateNow = DateTime.UtcNow;

            var (timesTamp, count) = memoryCache.GetOrCreate(cacheKey, entry =>
            {
                entry.AbsoluteExpirationRelativeToNow = rateLimitWindow;
                return (timesTamp : dateNow, count : 0);
            });

            if (dateNow - timesTamp < rateLimitWindow)
            {
                if (count >= 8) { return false; }
                memoryCache.Set(cacheKey, (timesTamp, count + 1),rateLimitWindow); 
            }
            else
            {
                memoryCache.Set(cacheKey, (timesTamp, count), rateLimitWindow);

            }
            return true;
        }

        private void ApplySecurity(HttpContext context)
        {
            context.Response.Headers["X-Content-Type-Options"] = "nosniff";
            context.Response.Headers["X-XSS-Protection"] = "1;mode=block";
            context.Response.Headers["X-Frame-Options"] = "DENY";
        }
    }
}

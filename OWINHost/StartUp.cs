using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Builder;


namespace OWINHost
{
    public class Startup
    {
        public void Configure(IApplicationBuilder app)
        {
            app.Use(async (context, next) =>
            {
                await context.Response.WriteAsync("Middleware One</br>");
                await next.Invoke();
            });

            app.Use(async (context, next) =>
            {
                await context.Response.WriteAsync("Middleware Two</br>");
                await next.Invoke();
            });

            app.Use(async (context, next) =>
            {
                await context.Response.WriteAsync("Middleware Three</br>");
                await next.Invoke();
            });
        }
    }
}
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

            app.MapWhen( context => context.Request.Query.ContainsKey("querypath1"), (appbuilder) =>
            {
                appbuilder.Use(async (context, next) =>
                {
                    await context.Response.WriteAsync("-- Map when -- querypath1 - Middleware One</br>");
                });
            });


            app.Map("/branch1", (appBuilder) =>
             {
                 appBuilder.Use(async (context, next) =>
                 {
                     await context.Response.WriteAsync("--Branch 1 - Middleware One</br>");
                     await next.Invoke();
                 });

                 appBuilder.Use(async (context, next) =>
                 {
                     await context.Response.WriteAsync("--Branch 2 - Middleware Two</br>");
                     await next.Invoke();
                 });
             });
        }
    }
}
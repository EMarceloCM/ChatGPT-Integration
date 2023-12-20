namespace Chatgpt.ASP.NET.Integration.Extensions
{
    public static class SwaggerExtensions
    {
        public static void AddSwagger(this IServiceCollection services)
        {
            services.AddSwaggerGen(c =>
            {
                c.SwaggerDoc("v1", new Microsoft.OpenApi.Models.OpenApiInfo
                {
                    Title = "ChatGPT ASP.NET 8 Integration",
                    Version = "v1"
                });

                c.ResolveConflictingActions(apiDescriptions => apiDescriptions.First());
            });
        }

        public static void UseSwaggerDoc(this IApplicationBuilder app)
        {
            app.UseSwagger();
            app.UseSwaggerUI(c =>
            {
                c.SwaggerEndpoint("/swagger/v1/swagger.json", "ChatGPT ASP.NET 8 Integration");
                c.RoutePrefix = "swagger";
            });
        }
    }
}

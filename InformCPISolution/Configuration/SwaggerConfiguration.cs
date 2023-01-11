using Microsoft.OpenApi.Models;

namespace InformCPISolution.Configuration
{
    public class SwaggerConfiguration
    {
        public static void SetupSwagger(IServiceCollection services)
        {
            services.AddEndpointsApiExplorer();
            services.AddSwaggerGen(options =>
            {
                //options.IncludeXmlComments(Path.Combine(PlatformServices.Default.Application.ApplicationBasePath,
                //  typeof(Program).GetTypeInfo().Assembly.GetName().Name + ".xml"));
                options.SwaggerDoc("v1", new OpenApiInfo
                {
                    Version = "v1",
                    Title = "I am a title API",
                    Description = "I am a description",
                    TermsOfService = new Uri("https://example.com/terms"),
                    Contact = new OpenApiContact
                    {
                        Name = "Example Contact",
                        Url = new Uri("https://example.com/contact")
                    },
                    License = new OpenApiLicense
                    {
                        Name = "Example License",
                        Url = new Uri("https://example.com/license")
                    }
                });
            });
        }
    }
}

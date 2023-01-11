using InformCPISolution.Domain.Contacts.Services;
using InformCPISolution.Domain.Contacts.Repository;
using AutoMapper;
using InformCPISolution.Mappers;

namespace InformCPISolution.Configuration
{
    public class StartupConfiguration
    {
            private static IConfiguration? Congfiguration;

            public static void RegisterRepositories(IServiceCollection services)
            {
                services.AddScoped<IContactRepository, ContactRepository>();
            }

            public static void RegisterServices(IServiceCollection services, IConfiguration configuration)
            {
                services.AddTransient<IContactServices, ContactServices>();

                //other services
                services.AddSingleton(configuration);

                var mapperConfig = new MapperConfiguration(mc =>
                {
                    mc.AddProfile(new ContactsProfile());
                });

                IMapper mapper = mapperConfig.CreateMapper();
                services.AddSingleton(mapper);

                Congfiguration = configuration;

                //setup caching
                services.AddMemoryCache();
                services.AddResponseCaching();
            }
    }
}

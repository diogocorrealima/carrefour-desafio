using SalesAPI.Infra.CrossCutting.IoC;

namespace SalesAPI.Services.API.Configurations
{
    public static class IoCConfig
    {
        public static void AddDependencyInjectionConfiguration(this IServiceCollection services)
        {
            if (services == null) throw new ArgumentNullException(nameof(services));

            BootStrapper.RegisterServices(services);
        }
    }
}

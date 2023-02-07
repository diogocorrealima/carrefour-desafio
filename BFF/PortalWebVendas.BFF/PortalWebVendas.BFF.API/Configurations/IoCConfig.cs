using PortalWebVendas.BFF.API.IoC;

namespace PortalWebVendas.BFF.API.Configurations
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

using PortalWebVendas.BFF.API.Interfaces;
using PortalWebVendas.BFF.API.Services;

namespace PortalWebVendas.BFF.API.IoC
{
    public static class BootStrapper
    {
        public static void RegisterServices(IServiceCollection services)
        {
            services.AddScoped<ISalesService, SalesService>();
            services.AddScoped<IProductService, ProductService>();
        }
    }
}

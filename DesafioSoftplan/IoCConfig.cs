using DesafioSoftplan.Interfaces;
using DesafioSoftplan.Services;
using Microsoft.Extensions.DependencyInjection;

namespace DesafioSoftplan
{

    public static class IoCConfig
    {

        public static void RegisterDependencies(IServiceCollection services)
        {
            services.AddScoped<IJurosService, JurosService>();
        }

    }

}

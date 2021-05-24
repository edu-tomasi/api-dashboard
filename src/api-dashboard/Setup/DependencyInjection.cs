using Microsoft.Extensions.DependencyInjection;
using WAProject.Data;
using WAProject.Data.Repository;
using WAProject.Domain;

namespace WAProject.API.Setup
{
    public static class DependencyInjection
    {

        public static void RegisterServices(this IServiceCollection services)
        {
            services.AddScoped<WAProjectContext>();

            services.AddScoped<IEquipeRepository, EquipeRepository>();
            services.AddScoped<IEncomendaRepository, EncomendaRepository>();
            services.AddScoped<IPedidoRepository, PedidoRepository>();
        }
    }
}

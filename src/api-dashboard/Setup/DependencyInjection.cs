using api_dashboard.Applcation;
using Microsoft.Extensions.DependencyInjection;
using WAProject.Data;
using WAProject.Data.Repository;
using WAProject.Domain;

namespace api_dashboard.Setup
{
    public static class DependencyInjection
    {

        public static void RegisterServices(this IServiceCollection services)
        {
            services.AddScoped<WAProjectContext>();

            services.AddScoped<IEquipeRepository, EquipeRepository>();
            services.AddScoped<IEncomendaRepository, EncomendaRepository>();
            services.AddScoped<IPedidoRepository, PedidoRepository>();

            services.AddScoped<IEncomendaService, EncomendaService>();
            
        }
    }
}

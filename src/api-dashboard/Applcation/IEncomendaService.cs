using System.Collections.Generic;
using System.Threading.Tasks;
using WAProject.Domain;

namespace api_dashboard.Applcation
{
    public interface IEncomendaService
    {
        public Task<IEnumerable<Encomenda>> ObterTodasEncomendasPorDataDeCriacao();
    }
}

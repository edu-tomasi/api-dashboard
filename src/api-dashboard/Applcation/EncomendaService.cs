using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using WAProject.Domain;

namespace api_dashboard.Applcation
{
    public class EncomendaService : IEncomendaService
    {
        private readonly IEncomendaRepository _repository;

        public EncomendaService(IEncomendaRepository repository)
        {
            _repository = repository;
        }
        public async Task<IEnumerable<Encomenda>> ObterTodasEncomendasPorDataDeCriacao()
        {
            var result = await _repository.ObterTodas();
            return result.OrderBy(e => e?.Pedido?.DataDeCriacao);
        }
    }
}

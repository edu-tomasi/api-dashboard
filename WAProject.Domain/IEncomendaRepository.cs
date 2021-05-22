using System;
using System.Collections.Generic;
using System.Threading.Tasks;
using WAProject.Core.Data;

namespace WAProject.Domain
{
    public interface IEncomendaRepository : IRepository<Encomenda>
    {
        Task<Encomenda> ObterPorId(Guid id);
        Task<Encomenda> ObterPorCodigo(string codigo);
        Task<IEnumerable<Encomenda>> ObterPorEquipe(Guid idEquipe);
        Task<IEnumerable<Encomenda>> ObterTodas();
        void Adicionar(Encomenda encomenda);
        void Atualizar(Encomenda encomenda);
        void Remover(Encomenda encomenda);
    }
}

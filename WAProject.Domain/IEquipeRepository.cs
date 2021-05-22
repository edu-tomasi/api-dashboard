using System;
using System.Collections.Generic;
using System.Threading.Tasks;
using WAProject.Core.Data;

namespace WAProject.Domain
{
    public interface IEquipeRepository : IRepository<Equipe>
    {
        Task<Equipe> ObterPorId(Guid id);
        Task<Equipe> ObterPorNome(string nome);
        Task<Equipe> ObterPorPlacaVeiculoUtilizado(string placaVeiculoUtilizado);
        Task<IEnumerable<Equipe>> ObterTodas();
        void Adicionar(Equipe equipe);
        void Atualizar(Equipe equipe);
        void Remover(Equipe equipe);
    }
}

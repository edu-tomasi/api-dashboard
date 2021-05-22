using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Threading.Tasks;
using WAProject.Core.Data;
using WAProject.Domain;

namespace WAProject.Data.Repository
{
    public class EquipeRepository : IEquipeRepository
    {
        private readonly WAProjectContext _context;
        public IUnitOfWork UnitOfWork => _context;

        public EquipeRepository(WAProjectContext context)
        {
            _context = context;
        }

        public async Task<Equipe> ObterPorId(Guid id)
        {
            return await _context.Equipes.FindAsync(id);
        }

        public async Task<Equipe> ObterPorNome(string nome)
        {
            return await _context.Equipes.FindAsync(nome);
        }

        public async Task<Equipe> ObterPorPlacaVeiculoUtilizado(string placaVeiculoUtilizado)
        {
            return await _context.Equipes.FindAsync(placaVeiculoUtilizado);
        }

        public async Task<IEnumerable<Equipe>> ObterTodas()
        {
            return await _context.Equipes.AsNoTracking().ToListAsync();
        }

        public void Adicionar(Equipe equipe)
        {
            _context.Equipes.Add(equipe);
        }

        public void Atualizar(Equipe equipe)
        {
            _context.Equipes.Update(equipe);
        }

        public void Remover(Equipe equipe)
        {
            _context.Equipes.Remove(equipe);
        }

        public void Dispose()
        {
            _context?.Dispose();
        }
    }
}

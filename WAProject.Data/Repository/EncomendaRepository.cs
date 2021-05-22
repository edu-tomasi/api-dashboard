using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using WAProject.Core.Data;
using WAProject.Domain;

namespace WAProject.Data.Repository
{
    public class EncomendaRepository : IEncomendaRepository
    {
        private readonly WAProjectContext _context;
        public IUnitOfWork UnitOfWork => _context;

        public EncomendaRepository(WAProjectContext context)
        {
            _context = context;
        }

        public void Adicionar(Encomenda encomenda)
        {
            _context.Encomendas.Add(encomenda);
        }

        public void Atualizar(Encomenda encomenda)
        {
            _context.Encomendas.Update(encomenda);
        }

        public async Task<Encomenda> ObterPorCodigo(string codigo)
        {
            return await _context.Encomendas.FindAsync(codigo);
        }

        public async Task<IEnumerable<Encomenda>> ObterPorEquipe(Guid idEquipe)
        {
            return await _context.Encomendas.Where(encomenda => encomenda.EquipeId == idEquipe).ToListAsync();
        }

        public async Task<Encomenda> ObterPorId(Guid id)
        {
            return await _context.Encomendas.FindAsync(id);
        }

        public async Task<IEnumerable<Encomenda>> ObterTodas()
        {
            return await _context.Encomendas.Include(s => s.Pedido).ThenInclude(s => s.PedidoItens).Include(s => s.Equipe).ToListAsync();
        }

        public void Remover(Encomenda encomenda)
        {
            _context.Encomendas.Remove(encomenda);
        }

        public void Dispose()
        {
            _context?.Dispose();
        }
    }
}

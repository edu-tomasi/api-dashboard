using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using WAProject.Core.Data;
using WAProject.Domain;

namespace WAProject.Data.Repository
{
    public class PedidoRepository : IPedidoRepository
    {
        private readonly WAProjectContext _context;
        public IUnitOfWork UnitOfWork => _context;

        public PedidoRepository(WAProjectContext context)
        {
            _context = context;
        }

        public void Adicionar(Pedido pedido)
        {
            _context.Pedidos.Add(pedido);
        }

        public void AdicionarItem(PedidoItem pedidoItem)
        {
            _context.PedidoItens.Add(pedidoItem);
        }

        public void Atualizar(Pedido pedido)
        {
            _context.Pedidos.Update(pedido);
        }

        public void AtualizarItem(PedidoItem pedidoItem)
        {
            _context.PedidoItens.Update(pedidoItem);
        }


        public async Task<PedidoItem> ObterItemPorId(Guid id)
        {
            return await _context.PedidoItens.FindAsync(id);
        }

        public async Task<PedidoItem> ObterItemPorPedido(Guid pedidoId, Guid produtoId)
        {
            return await _context.PedidoItens.FirstOrDefaultAsync(pedidoItem => pedidoItem.Id == produtoId /*&& pedidoItem.PedidoId == pedidoId*/);
        }

        public async Task<IEnumerable<Pedido>> ObterPorDataDeCriacao(DateTime dataDeCriacao)
        {
            return await _context.Pedidos.Where(pedido => pedido.DataDeCriacao == dataDeCriacao).Include(pedido => pedido.PedidoItens).ToListAsync();
        }

        public async Task<IEnumerable<Pedido>> ObterPorDataDeEntrega(DateTime? dataDeEntrega)
        {
            return await _context.Pedidos.Where(pedido => pedido.DataDeEntrega == dataDeEntrega).Include(pedido => pedido.PedidoItens).ToListAsync();
        }

        public async Task<Pedido> ObterPorId(Guid id)
        {
            var pedido = await _context.Pedidos.FirstOrDefaultAsync(pedido => pedido.Id == id);

            if (pedido == null) return null;

            await _context.Entry(pedido)
                .Collection(pedido => pedido.PedidoItens).LoadAsync();

            return pedido;
        }

        public async Task<Pedido> ObterPorNumeroIdentificacao(int numeroIdentificacao)
        {
            var pedido = await _context.Pedidos.FirstOrDefaultAsync(pedido => pedido.NumeroIdentificacao == numeroIdentificacao);

            if (pedido == null) return null;

            await _context.Entry(pedido)
                .Collection(pedido => pedido.PedidoItens).LoadAsync();

            return pedido;
        }

        public void Remover(Pedido pedido)
        {
            _context.Pedidos.Remove(pedido);
        }

        public void RemoverItem(PedidoItem pedidoItem)
        {
            _context.PedidoItens.Remove(pedidoItem);
        }

        public void Dispose()
        {
            _context?.Dispose();
        }
    }
}

using System;
using System.Collections.Generic;
using System.Threading.Tasks;
using WAProject.Core.Data;

namespace WAProject.Domain
{
    public interface IPedidoRepository : IRepository<Pedido>
    {
        Task<Pedido> ObterPorId(Guid id);
        Task<Pedido> ObterPorNumeroIdentificacao(int numeroIdentificacao);
        Task<IEnumerable<Pedido>> ObterPorDataDeCriacao(DateTime dataDeCriacao);
        Task<IEnumerable<Pedido>> ObterPorDataDeEntrega(DateTime? dataDeEntrega);
        void Adicionar(Pedido pedido);
        void Atualizar(Pedido pedido);
        void Remover(Pedido pedido);

        Task<PedidoItem> ObterItemPorId(Guid id);
        Task<PedidoItem> ObterItemPorPedido(Guid pedidoId, Guid produtoId);
        void AdicionarItem(PedidoItem pedidoItem);
        void AtualizarItem(PedidoItem pedidoItem);
        void RemoverItem(PedidoItem pedidoItem);
    }
}

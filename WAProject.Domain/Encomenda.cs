using System;
using WAProject.Core.DomainObjects;

namespace WAProject.Domain
{
    public class Encomenda : Entity, IAggregateRoot
    {
        public string Codigo { get; set; }
        public virtual Equipe Equipe { get; set; }
        public Guid EquipeId { get; set; }
        public virtual Pedido Pedido { get; set; }
        //public Guid PedidoId { get; set; }
    }
}

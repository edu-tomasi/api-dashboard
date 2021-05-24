using System;
using System.Collections.Generic;
using System.Text.Json.Serialization;
using WAProject.Core.DomainObjects;

namespace WAProject.Domain
{
    public class Pedido : Entity, IAggregateRoot
    {
        public int NumeroIdentificacao { get; set; }
        public DateTime DataDeCriacao { get; set; }
        public DateTime? DataDeEntrega { get; set; }
        public Endereco Endereco { get; set; }

        public Guid EncomendaId { get; set; }
        public ICollection<PedidoItem> PedidoItens { get; set; }
    }
}

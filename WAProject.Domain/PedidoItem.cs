using System;
using System.Text.Json.Serialization;
using WAProject.Core.DomainObjects;

namespace WAProject.Domain 
{ 
    public class PedidoItem : Entity
    {
        public Guid PedidoId { get; set; }
        public Guid ProdutoId { get; set; }
        public string Nome { get; set; }
        public string Descricao { get; set; }
        public decimal Valor { get; set; }
    }
}

using System.Collections.Generic;
using WAProject.Core.DomainObjects;

namespace WAProject.Domain
{
    public class Equipe : Entity, IAggregateRoot
    {
        public string Nome { get; set; }
        public string Descricao { get; set; }
        public string PlacaVeiculoUtilizado { get; set; }
    }
}

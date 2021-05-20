using System;

namespace api_dashboard.Domain.Entity
{
    public class Produto
    {
        public Guid Id { get; private set; }
        public string Nome { get; private set; }
        public string Descricao { get; private set; }
        public decimal Valor { get; private set; }

        public Produto(Guid id, string nome, string descricao, decimal valor)
        {
            Id = id;
            Nome = nome;
            Descricao = descricao;
            Valor = valor;

            Validar();
        }

        private void Validar()
        {
            if (string.IsNullOrEmpty(Nome) || string.IsNullOrWhiteSpace(Nome))
                throw new DomainException("Informe o nome do produto");

            if (Valor <= 0)
                throw new DomainException("O valor do produto deve ser maior do que R$ 0,00");
        }
    }
}

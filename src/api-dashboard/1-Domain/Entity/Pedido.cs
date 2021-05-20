using System;
using System.Collections.Generic;
using System.Linq;

namespace api_dashboard.Domain.Entity
{
    public class Pedido
    {
        public Guid Id { get; private set; }
        public DateTime DataDeCriacao { get; private set; }
        public DateTime DataDeEntrega { get; private set; }
        public string Endereco { get; private set; }

        private IList<Produto> _produtos;
        public IReadOnlyCollection<Produto> Produtos => _produtos.ToList();

        public Pedido(string endereco)
        {
            Id = Guid.NewGuid();
            DataDeCriacao = DateTime.Now;
            Endereco = endereco;
            _produtos = new List<Produto>();

            Validar();
        }

        private void Validar()
        {
            if (string.IsNullOrEmpty(Endereco) || string.IsNullOrWhiteSpace(Endereco))
                throw new DomainException("Informe o endereço");
        }

        public void AdicionarProduto(Guid id,string nome, string descricao, decimal valor)
        {
            var pedidoItem = new Produto(id, nome, descricao, valor);
            _produtos.Add(pedidoItem);
        }

        public void AlterarProduto(Guid id, string nome, string descricao, decimal valor)
        {
            var produtoEncontrado = _produtos.Any(p => p.Id == id);

            if (!produtoEncontrado)
                throw new DomainException("Produto não encontrado");

            var produtoAntigo = _produtos.FirstOrDefault(p => p.Id == id);
            var produtoAtualizado = new Produto(produtoAntigo.Id, nome, descricao, valor);

            _produtos.Remove(produtoAntigo);
            _produtos.Add(produtoAtualizado);
        }

        public void RemoverProduto(Guid id)
        {
            var produto = _produtos.FirstOrDefault(p => p.Id == id);
            _produtos.Remove(produto);
        }
    }
}

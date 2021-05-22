using api_dashboard.Domain;
using api_dashboard.Domain.Entity;
using System;
using System.Linq;
using Xunit;

namespace api_dashboard.tests
{
    public class PedidoTests
    {

        [Fact(DisplayName = "Endereço em Branco Deve Liberar Excessao")]
        [Trait("Categoria", "Pedido")]
        public void Pedido_EnderecoEmBranco_DeveLiberarExcessao()
        {
            // Arrange & Act & Assert
            var exception = Assert.Throws<DomainException>(() => new Pedido(String.Empty));
            Assert.Equal("Informe o endereço", exception.Message);
        }

        [Fact(DisplayName = "Endereço Somente Com Espaço Vazio Deve Liberar Excessao")]
        [Trait("Categoria", "Pedido")]
        public void Pedido_EnderecoComEspacoVazio_DeveLiberarExcessao()
        {
            // Arrange & Act & Assert
            var exception = Assert.Throws<DomainException>(() => new Pedido(" "));
            Assert.Equal("Informe o endereço", exception.Message);
        }

        [Fact(DisplayName = "Endereço Nulo Deve Liberar Excessao")]
        [Trait("Categoria", "Pedido")]
        public void Pedido_EnderecoNulo_DeveLiberarExcessao()
        {
            // Arrange & Act & Assert
            var exception = Assert.Throws<DomainException>(() => new Pedido(null));
            Assert.Equal("Informe o endereço", exception.Message);
        }

        [Fact(DisplayName = "Produto Adicionado Deve Constar Na Lista De Produtos")]
        [Trait("Categoria", "Pedido")]
        public void Pedido_AdicionarProduto_DeveConstarNaListaDeProdutos()
        {
            // Arrange
            var pedido = new Pedido("Endereço Exemplo");
            var produto = new Produto("Produto", "Descrição Exemplo", 10);

            // Act
            pedido.AdicionarProduto(produto.Nome, produto.Descricao, produto.Valor);

            // Assert
            Assert.Single(pedido.Produtos);
            Assert.True(pedido.Produtos.Any(p => p.Id == produto.Id));
        }

        [Fact(DisplayName = "Produto Alterado Deve Liberar Excessao Caso o Mesmo Não Seja Encontrado")]
        [Trait("Categoria", "Pedido")]
        public void Pedido_AlterarProduto_DeveLiberarExcessaoCasoOMesmoNaoSejaEncontrado()
        {
            // Arrange
            var pedido = new Pedido("Endereço Exemplo");
            var idProduto = Guid.NewGuid();

            pedido.AdicionarProduto("Produdo Exemplo", "Descrição Exemplo", 10m);

            // Act & Assert
            var exception = Assert.Throws<DomainException>(() => pedido.AlterarProduto(Guid.NewGuid(), "Produto Exemplo", "Descrição Exemplo", 9.99m));
            Assert.Equal("Produto não encontrado", exception.Message);
        }

        [Fact(DisplayName = "Produto Alterado Com Sucesso")]
        [Trait("Categoria", "Pedido")]
        public void Pedido_AlterarProduto_ProdutoAlteradoComSucesso()
        {
            // Arrange
            var pedido = new Pedido("Endereço Exemplo");
            var idProduto = Guid.NewGuid();
            var valorOriginal = 10m;
            var valorAtualizado = 9.99m;

            pedido.AdicionarProduto("Produdo Exemplo", "Descrição Exemplo", valorOriginal);

            // Act
            pedido.AlterarProduto(idProduto, "Produto Exemplo", "Descrição Exemplo", valorAtualizado);

            // Assert
            Assert.True(pedido.Produtos.Any(p => p.Id == idProduto && p.Valor == valorAtualizado));
            Assert.False(pedido.Produtos.Any(p => p.Id == idProduto && p.Valor == valorOriginal));
        }

        [Fact(DisplayName = "Produto Removido Com Sucesso")]
        [Trait("Categoria", "Pedido")]
        public void Pedido_RemoverProduto_ProdutoExcluidoComSucesso()
        {
            // Arrange
            var idProduto = Guid.NewGuid();
            var pedido = new Pedido("Endereço Exemplo");
            pedido.AdicionarProduto("Produto Exemplo", "Descrição Exemplo", 10);

            // Act
            pedido.RemoverProduto(idProduto);

            // Assert
            Assert.False(pedido.Produtos.Any(p => p.Id == idProduto));
        }
    }
}   

using api_dashboard.Domain;
using System;
using Xunit;

namespace api_dashboard.tests
{
    public class PedidoItemTests
    {
        [Fact(DisplayName = "Nome em Branco Deve Liberar Excessao")]
        [Trait("Categoria", "Pedido Item")]
        public void PedidoItem_NomeEmBranco_DeveLiberarExcessao()
        {
            // Arrange & Act & Assert
            var exception = Assert.Throws<DomainException>(() => new Produto(Guid.NewGuid(), string.Empty, "Descrição Produto", 10));
            Assert.Equal("Informe o nome do produto", exception.Message);
        }

        [Fact(DisplayName = "Nome Somente Com Espaço Vazio Deve Liberar Excessao")]
        [Trait("Categoria", "Pedido Item")]
        public void PedidoItem_NomeComEspacoVazio_DeveLiberarExcessao()
        {
            // Arrange & Act & Assert
            var exception = Assert.Throws<DomainException>(() => new Produto(Guid.NewGuid(), " ", "Descrição Produto", 10));
            Assert.Equal("Informe o nome do produto", exception.Message);
        }

        [Fact(DisplayName = "Nome Nulo Deve Liberar Excessao")]
        [Trait("Categoria", "Pedido Item")]
        public void PedidoItem_NomeNulo_DeveLiberarExcessao()
        {
            // Arrange & Act & Assert
            var exception = Assert.Throws<DomainException>(() => new Produto(Guid.NewGuid(),null, "Descrição Produto", 10));
            Assert.Equal("Informe o nome do produto", exception.Message);
        }

        [Fact(DisplayName = "Valor Do Produto Negativo")]
        [Trait("Categoria", "Pedido Item")]
        public void PedidoItem_ValorNegativo_DeveLiberarExcessao()
        {
            // Arrange & Act & Assert
            var exception = Assert.Throws<DomainException>(() => new Produto(Guid.NewGuid(), "Produto Exemplo", "Descrição Produto", -2));
            Assert.Equal("O valor do produto deve ser maior do que R$ 0,00", exception.Message);
        }

        [Fact(DisplayName = "Valor do Produto Zerado")]
        [Trait("Categoria", "Pedido Item")]
        public void PedidoItem_ValorZerado_DeveLiberarExcessao()
        {
            // Arrange & Act & Assert
            var exception = Assert.Throws<DomainException>(() => new Produto(Guid.NewGuid(), "Produto Exemplo", "Descrição Produto", 0));
            Assert.Equal("O valor do produto deve ser maior do que R$ 0,00", exception.Message);
        }
    }
}   

using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;
using WAProject.Domain;

namespace WAProject.Data.Mappings
{
    public class PedidoMapping : IEntityTypeConfiguration<Pedido>
    {
        public void Configure(EntityTypeBuilder<Pedido> builder)
        {
            builder.HasKey(c => c.Id);

            builder.Property(c => c.NumeroIdentificacao)
                .HasDefaultValueSql<int>("NEXT VALUE FOR MinhaSequenciaPedido");

            builder.Property(c => c.DataDeCriacao)
                .IsRequired();

            builder.Property(c => c.DataDeEntrega);

            builder.OwnsOne(c => c.Endereco, cm =>
            {
                cm.Property(c => c.Bairro)
                    .HasColumnName("Bairro")
                    .HasColumnType("varchar(250)")
                    .IsRequired();

                cm.Property(c => c.CEP)
                    .HasColumnName("CEP")
                    .HasColumnType("varchar(8)")
                    .IsRequired();

                cm.Property(c => c.Cidade)
                    .HasColumnName("Cidade")
                    .HasColumnType("varchar(250)")
                    .IsRequired();

                cm.Property(c => c.Logradouro)
                    .HasColumnName("Logradouro")
                    .HasColumnType("varchar(250)")
                    .IsRequired();

                cm.Property(c => c.Numero)
                    .HasColumnType("int")
                    .IsRequired();
            });

            builder.ToTable("Pedidos");
        }
    }
}

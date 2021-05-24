using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;
using WAProject.Domain;

namespace WAProject.Data.Mappings
{
    public class PedidoItemMapping : IEntityTypeConfiguration<PedidoItem>
    {
        public void Configure(EntityTypeBuilder<PedidoItem> builder)
        {
            builder.HasKey(c => c.Id);

            builder.Property(c => c.ProdutoId)
                .IsRequired();

            builder.Property(c => c.Nome)
                .HasColumnType("varchar(250)")
                .IsRequired();

            builder.Property(c => c.Descricao)
                .HasColumnType("varchar(500)");

            builder.Property(c => c.Valor)
                .IsRequired();

            builder.ToTable("PedidoItens");
        }
    }
}

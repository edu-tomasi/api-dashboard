using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;
using WAProject.Domain;

namespace WAProject.Data.Mappings
{
    public class EncomendaMapping : IEntityTypeConfiguration<Encomenda>
    {
        public void Configure(EntityTypeBuilder<Encomenda> builder)
        {
            builder.HasKey(c => c.Id);

            builder.Property(c => c.Codigo)
                .IsRequired()
                .HasColumnType("varchar(14)");

            //builder.HasOne(e => e.Pedido)
            //    .WithOne(p => p.Encomenda)
            //    .HasForeignKey<Pedido>(e => e.EncomendaId);
            builder.HasOne(e => e.Pedido);

            builder.ToTable("Encomendas");
        }
    }
}

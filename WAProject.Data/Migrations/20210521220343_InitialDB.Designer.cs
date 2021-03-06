// <auto-generated />
using System;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Infrastructure;
using Microsoft.EntityFrameworkCore.Metadata;
using Microsoft.EntityFrameworkCore.Migrations;
using Microsoft.EntityFrameworkCore.Storage.ValueConversion;
using WAProject.Data;

namespace WAProject.Data.Migrations
{
    [DbContext(typeof(WAProjectContext))]
    [Migration("20210521220343_InitialDB")]
    partial class InitialDB
    {
        protected override void BuildTargetModel(ModelBuilder modelBuilder)
        {
#pragma warning disable 612, 618
            modelBuilder
                .HasAnnotation("ProductVersion", "2.2.6-servicing-10079")
                .HasAnnotation("Relational:MaxIdentifierLength", 128)
                .HasAnnotation("Relational:Sequence:.MinhaSequenciaPedido", "'MinhaSequenciaPedido', '', '1000', '1', '', '', 'Int32', 'False'")
                .HasAnnotation("SqlServer:ValueGenerationStrategy", SqlServerValueGenerationStrategy.IdentityColumn);

            modelBuilder.Entity("WAProject.Domain.Encomenda", b =>
                {
                    b.Property<Guid>("Id")
                        .ValueGeneratedOnAdd();

                    b.Property<string>("Codigo")
                        .IsRequired()
                        .HasColumnType("varchar(14)");

                    b.Property<DateTime>("DataCadastro");

                    b.Property<Guid>("EquipeId");

                    b.Property<Guid>("PedidoId");

                    b.HasKey("Id");

                    b.HasIndex("EquipeId");

                    b.ToTable("Encomendas");
                });

            modelBuilder.Entity("WAProject.Domain.Equipe", b =>
                {
                    b.Property<Guid>("Id")
                        .ValueGeneratedOnAdd();

                    b.Property<DateTime>("DataCadastro");

                    b.Property<string>("Descricao")
                        .HasColumnType("varchar(500)");

                    b.Property<string>("Nome")
                        .IsRequired()
                        .HasColumnType("varchar(250)");

                    b.Property<string>("PlacaVeiculoUtilizado")
                        .IsRequired()
                        .HasColumnType("varchar(7)");

                    b.HasKey("Id");

                    b.ToTable("Equipes");
                });

            modelBuilder.Entity("WAProject.Domain.Pedido", b =>
                {
                    b.Property<Guid>("Id")
                        .ValueGeneratedOnAdd();

                    b.Property<DateTime>("DataCadastro");

                    b.Property<DateTime>("DataDeCriacao");

                    b.Property<DateTime?>("DataDeEntrega");

                    b.Property<Guid>("EncomendaId");

                    b.Property<int>("NumeroIdentificacao")
                        .ValueGeneratedOnAdd()
                        .HasDefaultValueSql("NEXT VALUE FOR MinhaSequenciaPedido");

                    b.HasKey("Id");

                    b.HasIndex("EncomendaId")
                        .IsUnique();

                    b.ToTable("Pedidos");
                });

            modelBuilder.Entity("WAProject.Domain.PedidoItem", b =>
                {
                    b.Property<Guid>("Id")
                        .ValueGeneratedOnAdd();

                    b.Property<DateTime>("DataCadastro");

                    b.Property<string>("Descricao")
                        .HasColumnType("varchar(500)");

                    b.Property<string>("Nome")
                        .IsRequired()
                        .HasColumnType("varchar(250)");

                    b.Property<Guid>("PedidoId");

                    b.Property<Guid>("ProdutoId");

                    b.Property<decimal>("Valor");

                    b.HasKey("Id");

                    b.HasIndex("PedidoId");

                    b.ToTable("PedidoItens");
                });

            modelBuilder.Entity("WAProject.Domain.Encomenda", b =>
                {
                    b.HasOne("WAProject.Domain.Equipe", "Equipe")
                        .WithMany()
                        .HasForeignKey("EquipeId");
                });

            modelBuilder.Entity("WAProject.Domain.Pedido", b =>
                {
                    b.HasOne("WAProject.Domain.Encomenda", "Encomenda")
                        .WithOne("Pedido")
                        .HasForeignKey("WAProject.Domain.Pedido", "EncomendaId");

                    b.OwnsOne("WAProject.Domain.Endereco", "Endereco", b1 =>
                        {
                            b1.Property<Guid>("PedidoId");

                            b1.Property<string>("Bairro")
                                .IsRequired()
                                .HasColumnName("Bairro")
                                .HasColumnType("varchar(250)");

                            b1.Property<string>("CEP")
                                .IsRequired()
                                .HasColumnName("CEP")
                                .HasColumnType("varchar(8)");

                            b1.Property<string>("Cidade")
                                .IsRequired()
                                .HasColumnName("Cidade")
                                .HasColumnType("varchar(250)");

                            b1.Property<string>("Logradouro")
                                .IsRequired()
                                .HasColumnName("Logradouro")
                                .HasColumnType("varchar(250)");

                            b1.Property<int>("Numero")
                                .HasColumnType("int");

                            b1.HasKey("PedidoId");

                            b1.ToTable("Pedidos");

                            b1.HasOne("WAProject.Domain.Pedido")
                                .WithOne("Endereco")
                                .HasForeignKey("WAProject.Domain.Endereco", "PedidoId");
                        });
                });

            modelBuilder.Entity("WAProject.Domain.PedidoItem", b =>
                {
                    b.HasOne("WAProject.Domain.Pedido", "Pedido")
                        .WithMany("PedidoItens")
                        .HasForeignKey("PedidoId");
                });
#pragma warning restore 612, 618
        }
    }
}

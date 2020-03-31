
using AuthJWT.Domain.Model.Entities;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;
using System.ComponentModel.DataAnnotations.Schema;

namespace PizzaHot.Domain.Model.Entities
{
    public class PedidoMap : IEntityTypeConfiguration<Pedido>
    {
        void IEntityTypeConfiguration<Pedido>.Configure(EntityTypeBuilder<Pedido> builder)
        {
            builder.ToTable("Pedidos");

            builder.HasKey(c => c.Id);

            builder.Property(c => c.Id).ValueGeneratedOnAdd();

            builder.Property(c => c.IdCliente)
                .HasColumnName("IdCliente")
                .HasColumnType("INT")
                .IsRequired();

            //builder
            //    .HasOne(u => u.Cliente)
            //    .WithOne(p => p.Pedido)
            //    .HasForeignKey<Usuarios>(b => b.Id) 
            //    .IsRequired();

            builder.Property(c => c.Preco)
                .HasColumnName("Preco")
                .HasColumnType("DECIMAL(10,3)")
                .IsRequired();

            builder.Property(c => c.TempoDePreparoEmMinutos)
                .HasColumnName("TempoDePreparoEmMinutos")
                .HasColumnType("INT")
                .IsRequired();

            builder.Property(c => c.StatusPedido)
                .HasColumnName("StatusPedido")
                .HasColumnType("TINYINT")
                .IsRequired();

            builder
                .HasMany<PersonalizacaoPedido>(u => u.PersonalizacaoPedido)
                .WithOne(p => p.Pedido)
                .HasForeignKey(b => b.IdPedido)
                .IsRequired();

            builder.OwnsOne(c => c.Pizza, pizza =>
            {
                pizza.Property(c => c.SaborEnum)
                    .IsRequired()
                    .HasColumnName("SaborPizza")
                    .HasColumnType("TINYINT");

                pizza.Property(c => c.TamanhoEnum)
                    .IsRequired()
                    .HasColumnName("TamanhoPizza")
                    .HasColumnType("TINYINT");
            });
        }
    }
}

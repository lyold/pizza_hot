
using AuthJWT.Domain.Model.Entities;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;

namespace PizzaHot.Domain.Model.Entities
{
    public class UsuariosMap : IEntityTypeConfiguration<Usuarios>
    {
        void IEntityTypeConfiguration<Usuarios>.Configure(EntityTypeBuilder<Usuarios> builder)
        {
            builder.ToTable("Usuarios");

            builder.HasKey(c => c.Id);

            builder.Property(c => c.Login)
                .HasColumnName("Login")
                .HasColumnType("VARCHAR(50)")
                .IsRequired();

            builder.Property(c => c.ChaveDeAcesso)
                .HasColumnName("ChaveDeAcesso")
                .HasColumnType("VARCHAR(50)")
                .IsRequired();

            builder
                .HasOne(u => u.Pedido)
                .WithOne(p => p.Cliente)
                .HasForeignKey<Pedido>(b => b.IdCliente)
                .IsRequired();
        }
    }
}

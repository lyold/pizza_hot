using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;

namespace PizzaHot.Domain.Model.Entities
{
    public class PersonalizacaoPedidoMap : IEntityTypeConfiguration<PersonalizacaoPedido>
    {
        void IEntityTypeConfiguration<PersonalizacaoPedido>.Configure(EntityTypeBuilder<PersonalizacaoPedido> builder)
        {
            builder.ToTable("PersonalizacaoPedido");

            builder.HasKey(c => c.Id);

            builder.Property(c => c.Id).ValueGeneratedOnAdd();

            builder.Property(c => c.IdPedido)
                .HasColumnName("IdPedido")
                .HasColumnType("INT")
                .IsRequired();

            builder.Property(c => c.IdPersonalizacao)
                .HasColumnName("IdPersonalizacao")
                .HasColumnType("INT")
                .IsRequired();
        }
    }
}

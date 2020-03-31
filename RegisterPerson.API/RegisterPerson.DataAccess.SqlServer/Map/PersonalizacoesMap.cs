using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;

namespace PizzaHot.Domain.Model.Entities
{
    public class PersonalizacoesMap : IEntityTypeConfiguration<Personalizacoes>
    {
        void IEntityTypeConfiguration<Personalizacoes>.Configure(EntityTypeBuilder<Personalizacoes> builder)
        {
            builder.ToTable("Personalizacoes");

            builder.HasKey(c => c.Id);

            builder.Property(c => c.Id).ValueGeneratedOnAdd();
            
            builder.Property(c => c.CustoAdicional)
                .HasColumnName("CustoAdicional")
                .HasColumnType("DECIMAL(10,3)")
                .IsRequired();

            builder.Property(c => c.TempoAdicionalPreparo)
                .HasColumnName("TempoAdicionalPreparo")
                .HasColumnType("INT")
                .IsRequired();

            builder.Property(c => c.TipoPersonalizacaoEnum)
                .HasColumnName("TipoPersonalizacao")
                .HasColumnType("TINYINT")
                .IsRequired();

            builder
                .HasMany<PersonalizacaoPedido>(u => u.PersonalizacaoPedido)
                .WithOne(p => p.Personalizacoes)
                .HasForeignKey(b => b.IdPersonalizacao)
                .IsRequired();
        }
    }
}


using Microsoft.EntityFrameworkCore;
using AuthJWT.Domain.Model.Entities;
using PizzaHot.Domain.Model.Entities;

namespace AuthJWT.DataAccess.SqlServer.Context
{
    public class SQLServerContext : DbContext
    {
        public DbSet<Usuarios> Usuarios { get; set; }
        public DbSet<Pedido> Pedidos { get; set; }
        public DbSet<Personalizacoes> Personalizacoes { get; set; }
        public DbSet<PersonalizacaoPedido> PersonalizacaoPedido { get; set; }

        public SQLServerContext(DbContextOptions<SQLServerContext> options) : base(options)
        {
        }

        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            modelBuilder.ApplyConfiguration(new PedidoMap());
            modelBuilder.ApplyConfiguration(new UsuariosMap());
            modelBuilder.ApplyConfiguration(new PersonalizacoesMap());
            modelBuilder.ApplyConfiguration(new PersonalizacaoPedidoMap());

            base.OnModelCreating(modelBuilder);
        }
        
    }
}

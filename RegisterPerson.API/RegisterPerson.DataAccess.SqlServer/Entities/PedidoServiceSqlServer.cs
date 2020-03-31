
using AuthJWT.DataAccess.Abstract.Entities;
using AuthJWT.DataAccess.SqlServer.Context;
using PizzaHot.Domain.Model.Entities;
using System;
using System.Linq;

namespace AuthJWT.API.Services.Context.Implementation
{
    public class PedidoServiceSqlServer : IPedidoServiceSqlServer
    {
        private SQLServerContext _context;

        public PedidoServiceSqlServer(SQLServerContext context)
        {
            this._context = context;
        }
        
        public Pedido InserirPedido(Pedido pedido)
        {
            try
            {
                _context.Add(pedido);
                _context.SaveChanges(); 
            }
            catch (Exception e)
            {
                throw e;
            }

            return pedido;
        }
        
        public Pedido ObterPedidoPorCliente(int idCliente)
        {
            return _context.Pedidos.Where(x => x.Cliente.Id == idCliente).FirstOrDefault();
        }

        public Pedido ObterPedidoPorId(int idPedido)
        {
            return _context.Pedidos.Where(x => x.Id == idPedido).FirstOrDefault();
        }
        
    }
}

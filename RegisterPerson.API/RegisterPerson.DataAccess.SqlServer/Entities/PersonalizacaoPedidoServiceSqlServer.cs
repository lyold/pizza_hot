
using AuthJWT.DataAccess.Abstract.Entities;
using AuthJWT.DataAccess.SqlServer.Context;
using PizzaHot.Domain.Model.Entities;
using System;
using System.Collections.Generic;
using System.Linq;

namespace AuthJWT.API.Services.Context.Implementation
{
    public class PersonalizacaoPedidoServiceSqlServer : IPedidoPersonalizacaoServiceSqlServer
    {
        private SQLServerContext _context;

        public PersonalizacaoPedidoServiceSqlServer(SQLServerContext context)
        {
            this._context = context;
        }

        public void DeletarPersonalizacao(List<PersonalizacaoPedido> itensPedido)
        {
            try
            {
                _context.RemoveRange(itensPedido);
                _context.SaveChanges();
            }
            catch (Exception e)
            {
                throw e;
            }
        }

        public List<PersonalizacaoPedido> InserirPersonalizacao(List<PersonalizacaoPedido> itensPedido)
        {
            try
            {
                _context.AddRange(itensPedido);
                _context.SaveChanges();
            }
            catch (Exception e)
            {
                throw e;
            }

            return itensPedido;
        }

        public List<PersonalizacaoPedido> ListarPersonalizacoesPorPedido(int idPedido)
        {
            return _context.PersonalizacaoPedido.Where(x => x.IdPedido == idPedido).ToList();
        }
    }
}

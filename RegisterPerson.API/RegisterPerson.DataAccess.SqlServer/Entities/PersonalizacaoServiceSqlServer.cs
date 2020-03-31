
using AuthJWT.DataAccess.Abstract.Entities;
using AuthJWT.DataAccess.SqlServer.Context;
using PizzaHot.Domain.Model.Entities;
using System.Collections.Generic;
using System.Linq;

namespace AuthJWT.API.Services.Context.Implementation
{
    public class PersonalizacaoServiceSqlServer : IPersonalizacaoServiceSqlServer
    {
        private SQLServerContext _context;

        public PersonalizacaoServiceSqlServer(SQLServerContext context)
        {
            this._context = context;
        }

        public Personalizacoes Find(int id)
        {
            return _context.Personalizacoes.Where(x => x.Id == id).FirstOrDefault();
        }

        public IEnumerable<Personalizacoes> FindAll()
        {
            return _context.Personalizacoes.ToList();
        }
    }
}

using System.Collections.Generic;
using AuthJWT.DataAccess.Abstract.Entities;
using AuthJWT.Domain.Services.Interfaces;
using PizzaHot.Domain.Model.Entities;

namespace AuthJWT.Domain.Services.Implementation
{ 
    public class PersonalizacaoService : IPersonalizacaoService
    {
        private IPersonalizacaoServiceSqlServer _personalizacaoServiceSqlServer;

        public PersonalizacaoService(IPersonalizacaoServiceSqlServer personalizacaoServiceSqlServer)
        {
            this._personalizacaoServiceSqlServer = personalizacaoServiceSqlServer;
        }

        public Personalizacoes Find(int id)
        {
            return _personalizacaoServiceSqlServer.Find(id);
        }

        public IEnumerable<Personalizacoes> FindAll()
        {
            return _personalizacaoServiceSqlServer.FindAll();
        }
    }
}

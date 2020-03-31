
using PizzaHot.Domain.Model.Entities;
using System.Collections.Generic;

namespace AuthJWT.DataAccess.Abstract.Entities
{
    public interface IPersonalizacaoServiceSqlServer
    {
        IEnumerable<Personalizacoes> FindAll();

        Personalizacoes Find(int id);
    }
}

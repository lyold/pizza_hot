
using PizzaHot.Domain.Model.Entities;
using System.Collections.Generic;

namespace AuthJWT.Domain.Services.Interfaces
{ 
    public interface IPersonalizacaoService
    {
        IEnumerable<Personalizacoes> FindAll();

        Personalizacoes Find(int id);
    }
}

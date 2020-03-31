
using AuthJWT.Domain.Model.Entities;
using System.Collections.Generic;

namespace AuthJWT.DataAccess.Abstract.Entities
{
    public interface IUserServiceSqlServer
    {

        Usuarios Create(Usuarios user);

        Usuarios Update(Usuarios user);

        void Delete(int id);

        Usuarios Find(int id);

        Usuarios FindByLogin(string login, string accessKey);

        IEnumerable<Usuarios> FindAll();
        
    }
}

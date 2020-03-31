
using AuthJWT.DataAccess.Abstract.Entities;
using AuthJWT.DataAccess.SqlServer.Context;
using AuthJWT.Domain.Model.Entities;
using System;
using System.Collections.Generic;
using System.Linq;

namespace AuthJWT.API.Services.Context.Implementation
{
    public class UserServiceSqlServer : IUserServiceSqlServer
    {
        private SQLServerContext _context;

        public UserServiceSqlServer(SQLServerContext context)
        {
            this._context = context;
        }

        public Usuarios Create(Usuarios user)
        {
            try
            {
                _context.Add(user);
                _context.SaveChanges();


            }catch(Exception e)
            {
                throw e;
            }

            return user;
        }

        public void Delete(int id)
        {
            try
            {
                Usuarios person = Find(id);

                _context.Remove(person);
                _context.SaveChanges();

            }catch(Exception e)
            {
                throw e;
            }
        }

        public Usuarios Find(int id)
        {
            return _context.Usuarios.Where(x=>x.Id == id).FirstOrDefault();
        }

        public IEnumerable<Usuarios> FindAll()
        {
            return _context.Usuarios.ToList(); 
        }

        public Usuarios FindByLogin(string login, string accessKey)
        {
            return _context.Usuarios.Where(x => x.Login == login && x.ChaveDeAcesso == accessKey).FirstOrDefault();
        }

        public Usuarios Update(Usuarios user)
        {
            Usuarios oldUser = Find(user.Id);

            try
            {
                oldUser.Login = user.Login;
                oldUser.ChaveDeAcesso = user.ChaveDeAcesso;

                _context.Update(oldUser);
                _context.SaveChanges();
            }
            catch(Exception e)
            {
                throw e;
            }
            
            return oldUser;
        }
    }
}

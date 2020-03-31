
using AuthJWT.Domain.Model.DTO;
using AuthJWT.Domain.Model.Entities;
using System.Collections.Generic;

namespace AuthJWT.Domain.Services.Interfaces
{ 
    public interface IUserService
    {
        ResultadoAutenticacaoDTO Authenticate(SolicitacaoDeAcessoDTO solicitacaoDeAcesso);

        void Loggout(Usuarios person);

        Usuarios Create(Usuarios person);

        Usuarios Update(Usuarios person);

        void Delete(int id);

        Usuarios Find(int id);
        
        List<Usuarios> FindAll();
    }
}

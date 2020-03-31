
using AuthJWT.Domain.Model.Entities;
using System;

namespace AuthJWT.Domain.Model.DTO
{
    public class ResultadoAutenticacaoDTO
    {
        public bool Autenticated { get; }
        
        public Usuarios User { get; }

        public DateTime DateCreated { get; }

        public DateTime DateExpiration { get; }

        public string Token { get; }

        public ResultadoAutenticacaoDTO(bool autenticated)
        {
            Autenticated = autenticated;
        }

        public ResultadoAutenticacaoDTO(bool autenticated, Usuarios user, DateTime dateCreated, DateTime dateExpiration, string token)
        {
            Autenticated = autenticated;
            User = user;
            DateCreated = dateCreated;
            DateExpiration = dateExpiration;
            Token = token;
        }
    }
}

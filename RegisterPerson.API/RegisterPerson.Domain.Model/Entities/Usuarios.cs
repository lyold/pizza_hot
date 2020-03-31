
using AuthJWT.Domain.Model.DTO;
using PizzaHot.Domain.Model.Entities;
using System.Collections.Generic;
using Tapioca.HATEOAS;

namespace AuthJWT.Domain.Model.Entities
{
    public class Usuarios //: ISupportsHyperMedia
    {
        public int Id { get; set; }

        public string Login { get; set; }

        public string ChaveDeAcesso { get; set; }

        public virtual Pedido Pedido { get; set; }

        //public List<HyperMediaLink> Links { get; set; } = new List<HyperMediaLink>();

        public UsuarioDTO ConverterParaDTO()
        {
            return new UsuarioDTO()
            {
                Id = this.Id,
                ChaveDeAcesso = this.ChaveDeAcesso,
                Login = this.Login
            };
        } 
    }
}

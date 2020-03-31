
using AuthJWT.Domain.Model.DTO;
using AuthJWT.Domain.Model.Entities;
using System.Collections.Generic;

namespace PizzaHot.Domain.Model.Entities
{
    public class Pedido
    {
        public int Id { get; set; }

        public int IdCliente { get; set; }

        public virtual Usuarios Cliente { get; set; }
        
        public PizzaVO Pizza { get; set; }
        
        public decimal Preco { get; set; }

        public int TempoDePreparoEmMinutos { get; set; }
        
        public StatusPedidoEnum StatusPedido { get; set; }

        public virtual List<PersonalizacaoPedido> PersonalizacaoPedido { get; set; }

        public PedidoDTO ConverterParaPedidoDTO()
        {
            PedidoDTO pedidoDTO = new PedidoDTO()
            {
                IdCliente = this.IdCliente,
                IdPedido = this.Id,
                Preco = this.Preco,
                SaborPizza = this.Pizza.SaborEnum,
                StatusPedido = this.StatusPedido,
                TamanhoPizza = this.Pizza.TamanhoEnum,
                TempoDePreparoEmMinutos = this.TempoDePreparoEmMinutos
            };

            return pedidoDTO;
        }

        //public Pedido(PizzaVO pizza, Usuarios cliente)
        //{
        //    Pizza = pizza;
        //    Cliente = cliente;
        //    StatusPedido = StatusPedidoEnum.Pendente;
        //}
    }
}

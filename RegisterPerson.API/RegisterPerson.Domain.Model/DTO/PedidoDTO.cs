
using AuthJWT.Domain.Model.Entities;

namespace AuthJWT.Domain.Model.DTO
{
    public class PedidoDTO
    {
        public int IdPedido { get; set; }
        
        public int IdCliente { get; set; }

        public SaborEnum SaborPizza { get; set; }

        public TamanhoEnum TamanhoPizza { get; set; }

        public StatusPedidoEnum StatusPedido { get; set; }

        public decimal Preco { get; set; }

        public int TempoDePreparoEmMinutos { get; set; }

    }
}

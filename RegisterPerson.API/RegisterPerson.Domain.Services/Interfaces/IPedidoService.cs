
using PizzaHot.Domain.Model.Entities;

namespace AuthJWT.Domain.Services.Interfaces
{ 
    public interface IPedidoService
    {
        Pedido CriarPedido(Pedido pedido);

        Pedido AtualizarPedido(Pedido pedido);

        Pedido ObterPedidoPorCliente(int idCliente);

        Pedido ObterPedidoPorId(int idPedido);

        Pedido CalcularPrecoPedido(Pedido pedido);

        Pedido CalcularTempoDePreparoDoPedido(Pedido pedido);
    }
}

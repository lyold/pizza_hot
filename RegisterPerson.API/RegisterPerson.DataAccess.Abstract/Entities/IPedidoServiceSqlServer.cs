
using PizzaHot.Domain.Model.Entities;

namespace AuthJWT.DataAccess.Abstract.Entities
{
    public interface IPedidoServiceSqlServer
    {

        Pedido InserirPedido(Pedido pedido);
        
        Pedido ObterPedidoPorCliente(int idCliente);

        Pedido ObterPedidoPorId(int idPedido);

    }
}

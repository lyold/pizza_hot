
using PizzaHot.Domain.Model.Entities;
using System.Collections.Generic;

namespace AuthJWT.DataAccess.Abstract.Entities
{
    public interface IPedidoPersonalizacaoServiceSqlServer
    {
        void DeletarPersonalizacao(List<PersonalizacaoPedido> itensPedido);

        List<PersonalizacaoPedido> InserirPersonalizacao(List<PersonalizacaoPedido> itensPedido);

        List<PersonalizacaoPedido> ListarPersonalizacoesPorPedido(int idPedido);
    }
}

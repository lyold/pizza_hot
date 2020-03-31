
using AuthJWT.Domain.Model.DTO;
using PizzaHot.Domain.Model.Entities;
using System.Collections.Generic;

namespace AuthJWT.Domain.Services.Interfaces
{ 
    public interface IPizzaService
    {
        PedidoDTO MontarPizza(SolicitacaoMontagemDTO solicitacaoMontagem);

        PedidoDTO PersonalizarPizza(SolicitacaoPersonalizacaoPedidoDTO personalizacao);
    }
}

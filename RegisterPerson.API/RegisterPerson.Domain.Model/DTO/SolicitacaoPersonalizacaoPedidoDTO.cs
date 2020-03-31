
using AuthJWT.Domain.Model.Entities;
using System.Collections.Generic;

namespace AuthJWT.Domain.Model.DTO
{
    public class SolicitacaoPersonalizacaoPedidoDTO
    {
        public int IdPedido { get; set; }

        public List<int> Personalizacoes { get; set; }

    }
}

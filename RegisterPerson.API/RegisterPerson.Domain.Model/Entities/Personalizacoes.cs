
using AuthJWT.Domain.Model.Entities;
using System.Collections.Generic;

namespace PizzaHot.Domain.Model.Entities
{
    public class Personalizacoes
    {
        public int Id { get; set; }
        
        public decimal CustoAdicional { get; set; }

        public int TempoAdicionalPreparo { get; set; }
        
        public TipoPersonalizacaoEnum TipoPersonalizacaoEnum { get; set; }

        public virtual List<PersonalizacaoPedido> PersonalizacaoPedido { get; set; }
    }
}

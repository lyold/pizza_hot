
namespace PizzaHot.Domain.Model.Entities
{
    public class PersonalizacaoPedido
    {
        public int Id { get; set; }
        
        public int IdPedido { get; set; }

        public virtual Pedido Pedido { get; set; }

        public int IdPersonalizacao { get; set; }

        public virtual Personalizacoes Personalizacoes { get; set; }
    }
}

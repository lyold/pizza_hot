
using AuthJWT.Domain.Model.Entities;

namespace AuthJWT.Domain.Model.DTO
{
    public class SolicitacaoMontagemDTO
    {
        public int IdCliente { get; set; }
        
        public TamanhoEnum TamanhoEnum { get; set; }

        public SaborEnum SaborEnum { get; set; }

    }
}

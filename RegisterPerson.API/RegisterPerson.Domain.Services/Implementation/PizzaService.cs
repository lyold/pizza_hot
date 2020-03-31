using System;
using System.Collections.Generic;
using System.Linq;
using AuthJWT.Domain.Model.DTO;
using AuthJWT.Domain.Model.Entities;
using AuthJWT.Domain.Services.Interfaces;
using PizzaHot.Domain.Model.Entities;

namespace AuthJWT.Domain.Services.Implementation
{ 
    public class PizzaService : IPizzaService
    {
        private IPedidoService _pedidoService;

        private IUserService _userService;

        private IPersonalizacaoService _personalizacaoService;

        public PizzaService(IPedidoService pedidoService, IUserService userService, IPersonalizacaoService personalizacaoService)
        {
            this._pedidoService = pedidoService;
            this._userService = userService;
            this._personalizacaoService = personalizacaoService;
        }

        public PedidoDTO MontarPizza(SolicitacaoMontagemDTO solicitacaoMontagem)
        {
            Pedido pedido = _pedidoService.ObterPedidoPorCliente(solicitacaoMontagem.IdCliente);
            if (pedido != null)
                throw new Exception("Já existe um pedido em andamento.");

            pedido = new Pedido();
            pedido.Pizza = new PizzaVO();
            pedido.Pizza.SaborEnum = solicitacaoMontagem.SaborEnum;
            pedido.Pizza.TamanhoEnum = solicitacaoMontagem.TamanhoEnum;

            pedido.Cliente = _userService.Find(solicitacaoMontagem.IdCliente);
            pedido.StatusPedido = StatusPedidoEnum.Pendente;

            pedido = _pedidoService.CalcularPrecoPedido(pedido);
            pedido = _pedidoService.CalcularTempoDePreparoDoPedido(pedido);

            return _pedidoService.CriarPedido(pedido).ConverterParaPedidoDTO();
        }
        
        public PedidoDTO PersonalizarPizza(SolicitacaoPersonalizacaoPedidoDTO personalizacao)
        {
            Pedido pedido = _pedidoService.ObterPedidoPorId(personalizacao.IdPedido);

            if(pedido == null)
                throw new Exception("Pedido não encontrado.");

            if (pedido.StatusPedido != StatusPedidoEnum.Pendente)
                throw new Exception("Não é possível personalizar o pedido pois o mesmo não está em andamento.");

            List<Personalizacoes> lista = new List<Personalizacoes>();
            foreach (var p in personalizacao.Personalizacoes)
                lista.Add(_personalizacaoService.Find(p));

            if (lista.Count(x => x.TipoPersonalizacaoEnum == TipoPersonalizacaoEnum.BordaRecheada) > 1)
                throw new Exception("Não é possível inserir mais de uma boarda recheada.");
            
            pedido.PersonalizacaoPedido = new List<PersonalizacaoPedido>();
            foreach (var p in lista)
                pedido.PersonalizacaoPedido.Add(new PersonalizacaoPedido() { IdPedido = pedido.Id, IdPersonalizacao = p.Id, Personalizacoes = p });

            pedido = _pedidoService.CalcularPrecoPedido(pedido);
            pedido = _pedidoService.CalcularTempoDePreparoDoPedido(pedido);

            return _pedidoService.AtualizarPedido(pedido).ConverterParaPedidoDTO();

        }
    }
}

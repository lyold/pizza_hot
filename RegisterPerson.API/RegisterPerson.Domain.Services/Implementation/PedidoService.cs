using System;
using System.Collections.Generic;
using System.Linq;
using AuthJWT.DataAccess.Abstract.Entities;
using AuthJWT.Domain.Model.DTO;
using AuthJWT.Domain.Model.Entities;
using AuthJWT.Domain.Services.Interfaces;
using PizzaHot.Domain.Model.Entities;

namespace AuthJWT.Domain.Services.Implementation
{ 
    public class PedidoService : IPedidoService
    {
        private IPedidoServiceSqlServer _pedidoServiceSqlServer;

        private IPedidoPersonalizacaoServiceSqlServer _pedidoPersonalizacaoServiceSqlServer;
        
        public PedidoService(IPedidoServiceSqlServer pedidoServiceSqlServer, IPedidoPersonalizacaoServiceSqlServer pedidoPersonalizacaoServiceSqlServer)
        {
            this._pedidoServiceSqlServer = pedidoServiceSqlServer;
            this._pedidoPersonalizacaoServiceSqlServer = pedidoPersonalizacaoServiceSqlServer;
        }
        
        public Pedido CalcularPrecoPedido(Pedido pedido)
        {
            switch (pedido.Pizza.TamanhoEnum)
            {
                case TamanhoEnum.Pequeno:
                    pedido.Preco = 20;
                    break;
                case TamanhoEnum.Medio:
                    pedido.Preco = 30;
                    break;
                case TamanhoEnum.Grande:
                    pedido.Preco = 40;
                    break;
                default:
                    throw new Exception("Não foi possível calcular o preço para o tamanho selecionado.");
            }

            // Aplica o adicional de custo
            if(pedido.PersonalizacaoPedido != null)
            {
                foreach (var personalizacao in pedido.PersonalizacaoPedido)
                    pedido.Preco = pedido.Preco + personalizacao.Personalizacoes.CustoAdicional;
            }
            
            return pedido;
        }

        public Pedido CalcularTempoDePreparoDoPedido(Pedido pedido)
        {
            switch (pedido.Pizza.TamanhoEnum)
            {
                case TamanhoEnum.Pequeno:
                    pedido.TempoDePreparoEmMinutos = 15;
                    break;
                case TamanhoEnum.Medio:
                    pedido.TempoDePreparoEmMinutos = 20;
                    break;
                case TamanhoEnum.Grande:
                    pedido.TempoDePreparoEmMinutos = 25;
                    break;
                default:
                    throw new Exception("Não foi possível calcular o preço para o tamanho selecionado.");
            }

            if (pedido.Pizza.SaborEnum == SaborEnum.Portuguesa)
                pedido.TempoDePreparoEmMinutos = pedido.TempoDePreparoEmMinutos + 5;

            // Aplica o adicional de prazo
            if (pedido.PersonalizacaoPedido != null)
            {
                foreach (var personalizacao in pedido.PersonalizacaoPedido)
                    pedido.TempoDePreparoEmMinutos += personalizacao.Personalizacoes.TempoAdicionalPreparo;
            }
            
            return pedido;
        }
        
        public Pedido CriarPedido(Pedido pedido)
        {
            Pedido pedidoCriado = _pedidoServiceSqlServer.InserirPedido(pedido);

            return pedidoCriado;
        }

        public Pedido AtualizarPedido(Pedido pedido)
        {
            List<PersonalizacaoPedido> adicionaisDoPedido = _pedidoPersonalizacaoServiceSqlServer.ListarPersonalizacoesPorPedido(pedido.Id);
            if(adicionaisDoPedido != null && adicionaisDoPedido.Any())
                _pedidoPersonalizacaoServiceSqlServer.DeletarPersonalizacao(adicionaisDoPedido);

            _pedidoPersonalizacaoServiceSqlServer.InserirPersonalizacao(pedido.PersonalizacaoPedido);

            return pedido;
        }

        public Pedido ObterPedidoPorCliente(int idCliente)
        {
            return _pedidoServiceSqlServer.ObterPedidoPorCliente(idCliente);
        }

        public Pedido ObterPedidoPorId(int idPedido)
        {
            return _pedidoServiceSqlServer.ObterPedidoPorId(idPedido);
        }
    }
}

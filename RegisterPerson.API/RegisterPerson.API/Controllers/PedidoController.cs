using Microsoft.AspNetCore.Mvc;
using AuthJWT.Domain.Services.Interfaces;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Http;
using System.Collections.Generic;
using PizzaHot.Domain.Model.Entities;
using AuthJWT.Domain.Model.DTO;

namespace AuthJWT.API.Controllers
{
    [Route("api/[controller]")]
    public class PedidoController : ControllerBase
    {
        private IPedidoService _pedidoService;
        
        public PedidoController(IPedidoService pedidoService)
        {
            this._pedidoService = pedidoService;
        }

        /// <summary>
        /// Retorna os pedidos de um determinado cliente
        /// </summary>
        /// <param name="id"></param>
        /// <returns></returns>
        [HttpGet("{id}")]
        [ProducesResponseType(StatusCodes.Status200OK, Type = typeof(List<PedidoDTO>))]
        [ProducesResponseType(StatusCodes.Status204NoContent)]
        [ProducesResponseType(StatusCodes.Status400BadRequest)]
        [ProducesResponseType(StatusCodes.Status401Unauthorized)]
        [Authorize("Bearer")]
        public ActionResult<List<Pedido>> Get(int id)
        {
            return Ok(_pedidoService.ObterPedidoPorCliente(id).ConverterParaPedidoDTO());
        }
    }
}

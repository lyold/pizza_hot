using System;
using Microsoft.AspNetCore.Mvc;
using AuthJWT.Domain.Services.Interfaces;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Http;
using AuthJWT.Domain.Model.DTO;

namespace AuthJWT.API.Controllers
{
    [Route("api/[controller]")]
    public class PizzaController : ControllerBase
    {
        private IPizzaService _pizzaService;
        
        public PizzaController(IPizzaService pizzaService)
        {
            this._pizzaService = pizzaService;
        }
        
        /// <summary>
        /// Inicia a montagem da Pizza
        /// </summary>
        /// <param name="solicitao">Sabor e Tamanho</param>
        /// <returns></returns>
        [HttpPost]
        [ProducesResponseType(StatusCodes.Status201Created, Type = typeof(PedidoDTO))]
        [ProducesResponseType(StatusCodes.Status400BadRequest)]
        [ProducesResponseType(StatusCodes.Status401Unauthorized)]
        [Authorize("Bearer")]
        public ActionResult MontarPizza([FromBody]SolicitacaoMontagemDTO solicitao)
        {
            try
            {
                return Ok(_pizzaService.MontarPizza(solicitao));
            }
            catch (Exception e)
            {
                return BadRequest(e.Message);
            }
        }

        /// <summary>
        /// Adiciona os adicionais da pizza
        /// </summary>
        /// <param name="personalizacao"></param>
        /// <returns></returns>
        [HttpPut]
        [ProducesResponseType(StatusCodes.Status201Created, Type = typeof(PedidoDTO))]
        [ProducesResponseType(StatusCodes.Status400BadRequest)]
        [ProducesResponseType(StatusCodes.Status401Unauthorized)]
        [Authorize("Bearer")]
        public ActionResult PersonalizarPizza([FromBody]SolicitacaoPersonalizacaoPedidoDTO personalizacao)
        {
            try
            {
                return Ok(_pizzaService.PersonalizarPizza(personalizacao));
            }
            catch (Exception e)
            {
                return BadRequest(e.Message);
            }
        }
    }
}

using System;
using Microsoft.AspNetCore.Mvc;
using AuthJWT.Domain.Services.Interfaces;
using Microsoft.AspNetCore.Authorization;
using AuthJWT.Domain.Model.DTO;

namespace AuthJWT.API.Controllers
{
    [Route("api/[controller]")]
    public class LoginController : ControllerBase
    {
        private IUserService _userService;
        
        public LoginController(IUserService userService)
        {
            this._userService = userService;
        }

        /// <summary>
        /// Serviço de autenticação (utilize o usário "teste" e senha "teste"
        /// </summary>
        /// <remarks>
        /// Serviço de autenticação (utilize o usário "teste" e senha "teste"
        /// </remarks>
        /// <param name="solicitacaoDeAcesso"></param>
        /// <returns></returns>
        [AllowAnonymous]
        [HttpPost]
        public object Post([FromBody]SolicitacaoDeAcessoDTO solicitacaoDeAcesso)
        {
            try
            {
                return Ok(_userService.Authenticate(solicitacaoDeAcesso));
            }catch(Exception e)
            {
                return BadRequest(e.Message);
            }
        }
    }
}

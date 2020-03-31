using System;
using System.Collections.Generic;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using AuthJWT.Domain.Services.Interfaces;
using AuthJWT.Domain.Model.Entities;
using Microsoft.AspNetCore.Authorization;
using Tapioca.HATEOAS;
using AuthJWT.Domain.Model.DTO;
using System.Linq;

namespace AuthJWT.API.Controllers
{
    [Route("api/[controller]")]
    public class UserController : ControllerBase
    {
        IUserService _userService;

        public UserController(IUserService userService)
        {
            this._userService = userService;
        }

        [HttpGet]
        [ProducesResponseType(StatusCodes.Status200OK)]
        [ProducesResponseType(StatusCodes.Status204NoContent)]
        [ProducesResponseType(StatusCodes.Status400BadRequest)]
        [ProducesResponseType(StatusCodes.Status401Unauthorized)]
        [Authorize("Bearer")]
        public ActionResult<IEnumerable<UsuarioDTO>> Get()
        {
            return Ok(_userService.FindAll().Select(x=>x.ConverterParaDTO()));
        }

        [HttpGet("{id}")]
        [ProducesResponseType(StatusCodes.Status200OK, Type = typeof(List<UsuarioDTO>))]
        [ProducesResponseType(StatusCodes.Status204NoContent)]
        [ProducesResponseType(StatusCodes.Status400BadRequest)]
        [ProducesResponseType(StatusCodes.Status401Unauthorized)]
        [Authorize("Bearer")]
        public ActionResult<string> Get(int id)
        {
            try
            {
                return Ok(_userService.Find(id).ConverterParaDTO());
            }
            catch (Exception e)
            {
                return BadRequest(e.Message);
            }
        }

        [HttpPost]
        [ProducesResponseType(StatusCodes.Status201Created, Type = typeof(UsuarioDTO))]
        [ProducesResponseType(StatusCodes.Status400BadRequest)]
        [ProducesResponseType(StatusCodes.Status401Unauthorized)]
        [Authorize("Bearer")]
        public ActionResult Post([FromBody]UsuarioDTO u)
        {
            try
            {
                Usuarios usuario = new Usuarios() { Login = u.Login, ChaveDeAcesso = u.ChaveDeAcesso };
                return Ok(_userService.Create(usuario).ConverterParaDTO());
            }catch(Exception e)
            {
                return BadRequest(e.Message);
            }
        }
        
        [HttpPut("{id}")]
        [ProducesResponseType(StatusCodes.Status202Accepted, Type = typeof(UsuarioDTO))]
        [ProducesResponseType(StatusCodes.Status400BadRequest)]
        [ProducesResponseType(StatusCodes.Status401Unauthorized)]
        [Authorize("Bearer")]
        public ActionResult Put([FromBody]UsuarioDTO u)
        {
            try
            {
                Usuarios usuario = new Usuarios() { Id = u.Id, Login = u.Login, ChaveDeAcesso = u.ChaveDeAcesso };
                return Ok(_userService.Update(usuario).ConverterParaDTO());
            }
            catch (Exception e)
            {
                return BadRequest(e.Message);
            }
        }

        [HttpDelete("{id}")]
        [ProducesResponseType(StatusCodes.Status204NoContent)]
        [ProducesResponseType(StatusCodes.Status400BadRequest)]
        [ProducesResponseType(StatusCodes.Status401Unauthorized)]
        [Authorize("Bearer")]
        public ActionResult Delete(int id)
        {
            try
            {
                _userService.Delete(id);
                return Ok();
            }
            catch (Exception e)
            {
                return BadRequest(e.Message);
            }
        }
    }
}

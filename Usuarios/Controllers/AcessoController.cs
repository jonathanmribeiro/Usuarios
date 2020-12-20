using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;
using System;
using System.Collections.Generic;
using Usuarios.Models;
using Usuarios.Services;

namespace Usuarios.Controllers
{

    /*
     Senha azure CGUFzCCIEB21
     */


    [Route("api/[controller]")]
    [ApiController]
    public class AcessoController : ControllerBase
    {
        private readonly IAcessoService _service;

        public AcessoController(IAcessoService service)
        {
            _service = service;
        }

        //Rotas anonimas --------------------------------------------------------------------------

        //POST api/acesso/login
        [HttpPost("login")]
        [AllowAnonymous]
        public IActionResult Login(User _usuario)
        {
            try
            {
                string token = _service.Login(_usuario);
                return Ok(new
                {
                    Token = token,
                    Usuario = _usuario.Name
                });
            }
            catch (Exception ex)
            {
                return BadRequest(new { Mensagem = ex.Message });
            }
        }

        //POST api/acesso
        [HttpPost]
        [AllowAnonymous]
        public IActionResult TrocarSenha(User _usuario)
        {
            try
            {
                User usuario = _service.TrocarSenha(_usuario);
                return Ok(new { Mensagem = "Senha alterada com sucesso.", Usuario = usuario });
            }
            catch (Exception ex)
            {
                return BadRequest(new { Mensagem = ex.Message });
            }
        }

        //PUT api/acesso/usuario
        [HttpPut("usuario")]
        [AllowAnonymous]
        public IActionResult CriarUsuario(User _usuario)
        {
            try
            {
                User usuario = _service.CriarUsuario(_usuario);
                return Ok(new { Mensagem = "Usuário criado com sucesso.", Usuario = usuario });
            }
            catch (Exception ex)
            {
                return BadRequest(new { Mensagem = ex.Message });
            }
        }

        //Rotas com restrição (CRUD)---------------------------------------------------------------

        //GET api/acesso/usuario
        [HttpGet("usuario")]
        [Authorize(Roles = "Diretor,Gerente,Colaborador")]
        public IActionResult ObterUsuarios()
        {
            try
            {
                List<User> usuarios = _service.ObterUsuarios();
                return Ok(new { Usuarios = usuarios });
            }
            catch (Exception ex)
            {
                return BadRequest(new { Mensagem = ex.Message });
            }
        }

        //POST api/acesso/usuario
        [HttpPost("usuario")]
        [Authorize(Roles = "Diretor,Gerente")]
        public IActionResult AlterarUsuario(User _usuario)
        {
            try
            {
                User usuario = _service.AlterarUsuario(_usuario);
                return Ok(new { Mensagem = "Usuário alterado com sucesso.", Usuario = usuario });
            }
            catch (Exception ex)
            {
                return BadRequest(new { Mensagem = ex.Message });
            }
        }

        //DELETE api/acesso/usuario
        [HttpDelete("usuario")]
        [Authorize(Roles = "Diretor")]
        public IActionResult RemoverUsuario(User _usuario)
        {
            try
            {
                _service.RemoverUsuario(_usuario);
                return Ok(new { Mensagem = "Usuário removido com sucesso." });
            }
            catch (Exception ex)
            {
                return BadRequest(new { Mensagem = ex.Message });
            }
        }
    }
}

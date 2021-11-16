using ITBIT.CORE.DTO;
using ITBIT.CORE.Servico;
using Microsoft.AspNetCore.Mvc;
using System;
using System.Collections.Generic;

namespace ITBIT.API.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class UsuarioController : ControllerBase
    {
        private readonly IServicoUsuario _servicoUsuario;

        public UsuarioController(IServicoUsuario servicoUsuario)
        {
            _servicoUsuario = servicoUsuario;
          
        }
       
        [HttpPost("cadastrousuario")]
        public IActionResult Post([FromBody]UsuarioRequest usuarioRequest)
        {
            string mensagem = "Usuário cadastrado com sucesso";
            
            try
            {
                _servicoUsuario.Salvar(usuarioRequest);
            
                return new JsonResult(mensagem);
            }
            catch(Exception ex)
            {
                mensagem = ex.Message;

                return BadRequest(mensagem);
            }
        }

        [HttpGet("obterusuariopornome")]
        public IEnumerable<UsuarioResponse> Get(string nomeUsuario)
        {
            try
            {
                return _servicoUsuario.GetUsuario(nomeUsuario);
            }

            catch(Exception ex)
            {

            }

            return new List<UsuarioResponse>();
            
        }

        [HttpPut("alterarstatusuario")]
        public IActionResult Put([FromBody]int idUsuario)
        {
            try
            {
               _servicoUsuario.Editar(idUsuario);
                return new JsonResult("Status alterado com sucesso");
            }
            catch(Exception ex)
            {
                return new JsonResult(ex.Message);
            }
          
        }

        [HttpPut("alterarusuario")]
        public IActionResult Put([FromBody] UsuarioRequest usuarioRequest)
        {
            try
            {
                _servicoUsuario.Editar(usuarioRequest);
                return new JsonResult("Operação realizada com sucesso");
            }
            catch (Exception ex)
            {
                return new JsonResult(ex.Message);
            }

        }

        [HttpGet("listartodosusuarios")]
        public IEnumerable<UsuarioResponse> Get()
        {
            try
            {
                return _servicoUsuario.GetUsuario();
            }
            catch(Exception ex)
            {

            }

            return new List<UsuarioResponse>();
        }

        [HttpDelete("excluirusuario")]
        public IActionResult Delete(int idUsuario)
        {
            try
            {
                _servicoUsuario.Excluir(idUsuario);
                return new JsonResult("Usuário excluído com sucesso");
            }
            catch(Exception ex)
            {
                return new JsonResult(ex.Message);
            }
        }
    }
}

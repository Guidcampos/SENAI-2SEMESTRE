using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using webapi.event_.tarde.Domains;
using webapi.event_.tarde.Interfaces;
using webapi.event_.tarde.Repositories;

namespace webapi.event_.tarde.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    [Produces("application/json")]

    public class UsuarioController : ControllerBase
    {
        private IUsuarioRepository _usuarioRepository { get; set; }

        public UsuarioController()
        {
            _usuarioRepository = new UsuarioRepository();
        }

        [HttpPost]

        public IActionResult Post (Usuario usuario)
        {
            try
            {
                _usuarioRepository.Cadastrar(usuario);
                return StatusCode(201);
            }
            catch (Exception e)
            {
                return BadRequest(e.Message);
            }
        }

        [HttpGet]
        public IActionResult Get (string email, string senha)
        {
            try
            {
                Usuario usuarioBuscado = _usuarioRepository.BuscarPorEmailESenha(email, senha);
                return Ok(usuarioBuscado);
            }
            catch (Exception)
            {

                throw;
            }
        }

        [HttpGet("{id}")]

        public IActionResult GetById (Guid id)
        {
            try
            {
                Usuario usuarioBuscado = _usuarioRepository.BuscarPorId(id);
                return Ok(usuarioBuscado);
            }
            catch (Exception)
            {

                throw;
            }
        }
    }
}

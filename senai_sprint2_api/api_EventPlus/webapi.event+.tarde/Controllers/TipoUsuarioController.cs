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
    public class TipoUsuarioController : ControllerBase
    {
        private ITipoUsuarioRepository _tipoUsuarioRepository { get; set; }

        public TipoUsuarioController()
        {
            _tipoUsuarioRepository = new TipoUsuarioRepository();
        }

        [HttpPost]
        public IActionResult Post(TipoUsuario tipoUsuario)
        {
            try
            {
                _tipoUsuarioRepository.Cadastrar(tipoUsuario);

                return StatusCode(201);
            }
            catch (Exception e)
            {

                return BadRequest(e.Message);
            }
        }

        [HttpGet]

        public IActionResult GetAll()
        {
            try
            {
                
                return Ok(_tipoUsuarioRepository.Listar());

            }
            catch (Exception e)
            {

                return BadRequest(e.Message);
            }
        }

        [HttpDelete("{id}")]

        public IActionResult Delete (Guid id)
        {
            try
            {
                _tipoUsuarioRepository.Deletar(id);

                return NoContent();
            }
            catch (Exception e)
            {
                return BadRequest(e.Message);
            }
        }

        [HttpGet("{id}")]

        public IActionResult GetById (Guid id)
        {
            try
            {
                TipoUsuario tipoUsuarioBuscado = _tipoUsuarioRepository.BuscarPorId(id);
                return Ok(tipoUsuarioBuscado);
            }
            catch (Exception e)
            {
                return BadRequest(e.Message);
            }
        }

        [HttpPut("{id}")]
        public IActionResult Post(Guid id, TipoUsuario tipo)
        {
            try
            {
                _tipoUsuarioRepository.Atualizar(id, tipo);
                return NoContent();
            }
            catch (Exception e)
            {
                return BadRequest(e.Message);
            }
        }
    }
}
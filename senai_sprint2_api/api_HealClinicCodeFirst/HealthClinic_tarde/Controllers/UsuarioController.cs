using HealthClinic_tarde.Domains;
using HealthClinic_tarde.Interfaces;
using HealthClinic_tarde.Repositories;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;

namespace HealthClinic_tarde.Controllers
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

        public ActionResult Cadastrar (Usuario usuario)
        {
            try
            {
            _usuarioRepository.Cadastrar(usuario);
            return StatusCode(201);

            }
            catch (Exception e)
            {

                return BadRequest(e.Message);
            };
        }

        [HttpGet]

        public ActionResult listar()
        {
            try
            {
                return Ok(_usuarioRepository.Listar());
            }
            catch (Exception e)
            {
                    return BadRequest(e.Message);
            }
        }

    }
}

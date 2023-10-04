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
    public class TipoUsuarioController : ControllerBase
    {
        private ITipoUsuarioRepository _tipoUsuariorepositoryRepository;

        public TipoUsuarioController()
        {
            _tipoUsuariorepositoryRepository = new TipoUsuarioRepository();

        }
        /// <summary>
        /// Metodo para cadastrar tipo de usuario
        /// </summary>
        /// <param name="tipoUsuario"></param>
        /// <returns></returns>
        [HttpPost]

        public IActionResult Cadastrar(TipoUsuario tipoUsuario)
        {
            try
            {
                _tipoUsuariorepositoryRepository.Cadastrar(tipoUsuario);
                return StatusCode(201);
            }
            catch (Exception e)
            {
                return BadRequest(e.Message);
            }

        }
        /// <summary>
        /// Metodo para listar tipo de usuario
        /// </summary>
        /// <returns></returns>
        [HttpGet]
        public IActionResult Listar()
        {
            try
            {
                return Ok(_tipoUsuariorepositoryRepository.Listar());
            }
            catch (Exception error)
            {
                return BadRequest(error.Message);
            }


        }
    }
}

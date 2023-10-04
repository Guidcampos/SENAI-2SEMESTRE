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
    public class PacienteController : ControllerBase
    {
        private IPacienteRepository _pacienteRepository;

        public PacienteController()
        {
            _pacienteRepository = new PacienteRepository();

        }
        /// <summary>
        /// Metodo para cadastrar paciente
        /// </summary>
        /// <param name="paciente"></param>
        /// <returns></returns>
        [HttpPost]
        public IActionResult Cadastrar(Paciente paciente)
        {
            try
            {
                _pacienteRepository.Cadastrar(paciente);
                return StatusCode(201);
            }
            catch (Exception e)
            {
                return BadRequest(e.Message);
            }

        }
        /// <summary>
        /// Metodo para listar paciente
        /// </summary>
        /// <returns></returns>
        [HttpGet]
        public IActionResult Listar()
        {
            try
            {
                return Ok(_pacienteRepository.Listar());

            }
            catch (Exception e)
            {
                return BadRequest(e.Message);
            }
        }
        /// <summary>
        /// Metodo para deletar paciente
        /// </summary>
        /// <param name="id"></param>
        /// <returns></returns>
        [HttpDelete("{id}")]

        public IActionResult Delete(Guid id)
        {
            try
            {
                _pacienteRepository.Deletar(id);
                return NoContent();
            }
            catch (Exception error)
            {
                return BadRequest(error.Message);
            }
        }

    }

}

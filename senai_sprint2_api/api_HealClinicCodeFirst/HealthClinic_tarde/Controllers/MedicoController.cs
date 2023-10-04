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
    public class MedicoController : ControllerBase
    {
        private IMedicoRepository _medicoRepository;

        public MedicoController()
        {
            _medicoRepository = new MedicoRepository();

        }
        /// <summary>
        /// Metodo para cadastrar medico
        /// </summary>
        /// <param name="medico"></param>
        /// <returns></returns>
        [HttpPost]
        public IActionResult Cadastrar(Medico medico)
        {
            try
            {
                _medicoRepository.Cadastrar(medico);
                return StatusCode(201);
            }
            catch (Exception e)
            {
                return BadRequest(e.Message);
            }

        }
        /// <summary>
        /// Metodo para listar medico
        /// </summary>
        /// <returns></returns>
        [HttpGet]
        public IActionResult Listar()
        {
            try
            {
                return Ok(_medicoRepository.Listar());

            }
            catch (Exception e)
            {
                return BadRequest(e.Message);
            }
        }
        /// <summary>
        /// Metodo para deletar medico
        /// </summary>
        /// <param name="id"></param>
        /// <returns></returns>
        [HttpDelete("{id}")]

        public IActionResult Delete(Guid id)
        {
            try
            {
                _medicoRepository.Deletar(id);
                return NoContent();
            }
            catch (Exception error)
            {
                return BadRequest(error.Message);
            }
        }

    }
}

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
    public class ClinicaController : ControllerBase
    {
        private IClinicaRepository _clinicaRepository { get; set; }

        public ClinicaController()
        {
            _clinicaRepository = new ClinicaRepository();
        }

        /// <summary>
        /// Metodo de cadastro de clinica
        /// </summary>
        /// <param name="clinica"></param>
        /// <returns></returns>
        [HttpPost]
        public IActionResult Cadastrar(Clinica clinica)
        {
            try
            {
                _clinicaRepository.Cadastrar(clinica);
                return StatusCode(201);
            }
            catch (Exception e)
            {
                return BadRequest(e.Message);
            }
           
        }
        /// <summary>
        /// Metodo para listar clinicas
        /// </summary>
        /// <returns></returns>
        [HttpGet]
        public IActionResult Listar()
        {
            try
            {
                return Ok(_clinicaRepository.Listar());
            }
            catch (Exception error)
            {
                return BadRequest(error.Message);  
            }

            
        }
        /// <summary>
        /// Metodo para deletar clinica
        /// </summary>
        /// <param name="id"></param>
        /// <returns></returns>
        [HttpDelete("{id}")]

        public IActionResult Delete(Guid id)
        {
            try
            {
                _clinicaRepository.Deletar(id);
                return NoContent();
            }
            catch (Exception error)
            {
                return BadRequest(error.Message);
            }
        }
    }
}




using HealthClinic_tarde.Domains;
using HealthClinic_tarde.Interfaces;
using HealthClinic_tarde.Repositories;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;

namespace HealthClinic_tarde.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class ConsultaController : ControllerBase
    {

        private IConsultaRepository _consultaRepository;

        public ConsultaController()
        {
            _consultaRepository = new ConsultaRepository();

        }

        [HttpPost]
        public IActionResult Cadastrar(Consulta consulta)
        {
            try
            {
                _consultaRepository.Cadastrar(consulta);
                return StatusCode(201);
            }
            catch (Exception e)
            {
                return BadRequest(e.Message);
            }

        }
        [Authorize]
        [HttpGet]
        public IActionResult Listar()
        {
            try
            {
                return Ok(_consultaRepository.Listar());

            }
            catch (Exception e)
            {
                return BadRequest(e.Message);
            }
        }
        /// <summary>
        /// deleta uma consulta
        /// </summary>
        /// <param name="id">id da consulta</param>
        /// <returns>status code noContent</returns>
        [HttpDelete("{id}")]

        public IActionResult Delete(Guid id)
        {
            try
            {
                _consultaRepository.Deletar(id);
                return NoContent();
            }
            catch (Exception error)
            {
                return BadRequest(error.Message);
            }
        }
       /// <summary>
       /// Listar consultas do paciente
       /// </summary>
       /// <param name="id">ID DO PACIENTE</param>
       /// <returns>Todas as consultas daquele paciente</returns>
        [HttpGet("Paciente/{id}")]
        
        public IActionResult ListarPacientes(Guid id)
        {

            try
            {

                return Ok(_consultaRepository.Listar().Where(a => a.IdPaciente == id));

            }
            catch (Exception e)
            {
                return BadRequest(e.Message);
            }
        }
        /// <summary>
        /// Lista as consultas do medico
        /// </summary>
        /// <param name="id">id do medico</param>
        /// <returns>Lista das consultas do medico</returns>
        [HttpGet("Medico/{id}")]
    

        public IActionResult ListarMedico(Guid id)
        {

            try
            {

                return Ok(_consultaRepository.Listar().Where(a => a.IdMedico == id));

            }
            catch (Exception e)
            {
                return BadRequest(e.Message);
            }
        }

    }
}

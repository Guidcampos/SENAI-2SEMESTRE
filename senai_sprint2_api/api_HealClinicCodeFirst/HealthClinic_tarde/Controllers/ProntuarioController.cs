﻿using HealthClinic_tarde.Domains;
using HealthClinic_tarde.Interfaces;
using HealthClinic_tarde.Repositories;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;

namespace HealthClinic_tarde.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    [Produces("application/json")]
    public class ProntuarioController : ControllerBase
    {

        private IProntuarioRepository _prontuarioRepository;

        public ProntuarioController()
        {
            _prontuarioRepository = new ProntuarioRepository();

        }
        /// <summary>
        /// Metodo para cadastrar prontuario
        /// </summary>
        /// <param name="prontuario"></param>
        /// <returns></returns>
        [HttpPost]
        public IActionResult Cadastrar(Prontuario prontuario)
        {
            try
            {
                _prontuarioRepository.Cadastrar(prontuario);
                return StatusCode(201);
            }
            catch (Exception e)
            {
                return BadRequest(e.Message);
            }

        }
        /// <summary>
        /// Metodo para listar prontuarios
        /// </summary>
        /// <returns></returns>
        [HttpGet]
        public IActionResult Listar()
        {
            try
            {
                return Ok(_prontuarioRepository.Listar());

            }
            catch (Exception e)
            {
                return BadRequest(e.Message);
            }
        }
        /// <summary>
        /// Metodo para deletar prontuario
        /// </summary>
        /// <param name="id"></param>
        /// <returns></returns>
        [HttpDelete("{id}")]

        public IActionResult Delete(Guid id)
        {
            try
            {
                _prontuarioRepository.Deletar(id);
                return NoContent();
            }
            catch (Exception error)
            {
                return BadRequest(error.Message);
            }
        }

    }
}


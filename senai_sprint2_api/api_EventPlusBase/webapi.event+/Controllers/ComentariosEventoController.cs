﻿using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using webapi.event_.Domains;
using webapi.event_.Interfaces;
using webapi.event_.Repositories;

namespace webapi.event_.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    [Produces("application/json")]
    public class ComentariosEventoController : ControllerBase
    {
        ComentariosEventoRepository comentario = new ComentariosEventoRepository();



        [HttpGet]
        
        public IActionResult Get()
        {
            try
            {
                return Ok(comentario.Listar());
            }
            catch (Exception e)
            {
                return BadRequest(e.Message);
                throw;
            }
        }

        [HttpGet("BuscarPorIdUsuario/{id}")]

        public IActionResult GetByUser (Guid id, Guid idEvento)
        {
            try
            {
                return Ok(comentario.BuscarPorIdUsuario(id, idEvento));
            }
            catch (Exception e)
            {
                return BadRequest(e.Message);
                throw;
            }
        }

        [HttpPost]

        public IActionResult Post(ComentariosEvento novoComentario)
        {
            try
            {
                comentario.Cadastrar(novoComentario);
                return StatusCode(201, novoComentario);
            }
            catch (Exception e)
            {
                return BadRequest(e.Message);
                throw;
            }
        }

        [HttpDelete("{id}")]

        public IActionResult Delete(Guid id)
        {
            try
            {
                comentario.Deletar(id);
                return NoContent();
            }
            catch (Exception e)
            {

                return BadRequest(e.Message);
            }
        }


    }
}
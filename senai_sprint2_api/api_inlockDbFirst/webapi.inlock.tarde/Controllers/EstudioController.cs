using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using webapi.inlock.tarde.Domains;
using webapi.inlock.tarde.Interfaces;
using webapi.inlock.tarde.Repositories;

namespace webapi.inlock.tarde.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    [Produces("application/json")]
    public class EstudioController : ControllerBase
    {
        private IEstudioRepository _estudioRepository;

        public EstudioController()
        {
            _estudioRepository = new EstudioRepository();
        }

        [HttpGet]

        public IActionResult Get()
        {
            try
            {
                return Ok(_estudioRepository.Listar());
            }
            catch (Exception erro)
            {
                return BadRequest(erro.Message);
            }
        }

        [HttpGet("IncludeJogos")]

        public IActionResult GetJogos()
        {

            try
            {
                return Ok(_estudioRepository.ListarComJogos());
            }
            catch (Exception erro)
            {
                return BadRequest(erro.Message);
            }

        }

        [HttpGet("{id}")]

        public IActionResult GetId(Guid id)
        {
            try
            {
                return Ok(_estudioRepository.BuscarPorId(id));
            }
            catch (Exception erro)
            {
                return BadRequest(erro.Message);
            }
        }

        [HttpDelete("{id}")]
        public IActionResult Delete(Guid id)
        {
            try
            {
                _estudioRepository.Deletar(id);

                return NoContent();
            }
            catch (Exception e)
            {
                return BadRequest(e.Message);
            }
        }

        [HttpPost]

        public IActionResult Post(Estudio estudio)
        {
           
            try
            {
            _estudioRepository.Cadastrar(estudio);

                return StatusCode(201);

            }
            catch (Exception erro)
            {

                return BadRequest(erro.Message);
            }
        }

        [HttpPut("{id}")]

        public IActionResult Put(Guid id, Estudio estudioNovo)
        {
            try
            {
            _estudioRepository.Atualizar(id, estudioNovo);
                return NoContent();

            }
            catch (Exception erro)
            {

                return BadRequest(erro.Message);
            }
        }

    }
}

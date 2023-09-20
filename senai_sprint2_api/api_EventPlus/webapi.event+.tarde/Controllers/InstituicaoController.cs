using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using webapi.event_.tarde.Interfaces;
using webapi.event_.tarde.Repositories;
using webapi.event_.tarde.Domains;

namespace webapi.event_.tarde.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    [Produces("application/json")]
    public class InstituicaoController : ControllerBase
    {
        private readonly IInstituicaoRepository _instituicaoRepository;
        public InstituicaoController()
        {
            _instituicaoRepository = new InstituicaoRepository();
        }


        [HttpPost]
        public IActionResult Post(Instituicao instituicao)
        {
            try
            {
                _instituicaoRepository.Cadastrar(instituicao);
                return StatusCode(201);
            }
            catch (Exception e)
            {

                return BadRequest(e.Message);
            }
        }

       

        [HttpDelete("{id}")]
        public IActionResult Delete(Guid id)
        {
            try
            {
                _instituicaoRepository.Deletar(id);
                return NoContent();
            }
            catch (Exception e)
            {

                return BadRequest(e.Message);
            }

        }
    }
}

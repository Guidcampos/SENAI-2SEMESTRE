using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using webapi.filmes.tarde.Domains;
using webapi.filmes.tarde.Interfaces;
using webapi.filmes.tarde.Repositories;

namespace webapi.filmes.tarde.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    /// <summary>
    /// Define qual é o tipo de resposta da API
    /// </summary>
    [Produces("application/json")]
    public class FilmeController : ControllerBase
    {

        private IFilmeRepository _filmeRepository { get; set; }

        public FilmeController()
        {
            _filmeRepository = new FilmeRepository();
        }

        /// <summary>
        /// EndPoint que acessa um metodo de listar os filmes 
        /// </summary>
        /// <returns>Lista de filmes e um status code</returns>
        [HttpGet]
        public IActionResult Get()
        {
            try
            {

                //Cria uma lista para receber os generos
                List<FilmeDomain> ListaFilme = _filmeRepository.ListarTodos();

                //retorna o STATUS CODE 200 OK, junto com a lista de generos no formato JSON
                return Ok(ListaFilme);

            }
            catch (Exception erro)
            {

                //Retorna um status code 400, com uma mensagem de erro
                return BadRequest(erro.Message);

            }

        }

        /// <summary>
        /// Endpoint para buscar por id
        /// </summary>
        /// <param name="id"></param>
        /// <returns></returns>
        [HttpGet("{id}")]
        public IActionResult Get(int id)
        {
            try
            {
                FilmeDomain filmeBuscado = _filmeRepository.BuscarPorId(id);

                if (filmeBuscado == null)
                {
                    return NotFound("O genero buscado não foi encontrado");
                }

                return Ok(filmeBuscado);
            }
            catch (Exception erro)
            {
                return BadRequest(erro.Message);
            }
        }



    }

}

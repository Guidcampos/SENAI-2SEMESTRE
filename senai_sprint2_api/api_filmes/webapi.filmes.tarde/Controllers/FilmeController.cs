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
        /// Cadastra um novo filme
        /// </summary>
        /// <param name="novoFilme">Objeto novoFilme recebido na requisição</param>
        /// <returns>Um status code 201 - Created</returns>
        [HttpPost]
        public IActionResult Post(FilmeDomain novoFilme)
        {
            try
            {
                // Faz a chamada para o método .Cadastrar()
                _filmeRepository.Cadastrar(novoFilme);

                // Retorna um status code 201 - Created
                return StatusCode(201);
            }
            catch (Exception erro)
            {

                // Retorna um status 400 - BadRequest e o código do erro
                return BadRequest(erro);
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


        /// <summary>
        /// Atualiza um filme existente passando o seu id pelo corpo da requisição
        /// </summary>
        /// <param name="filmeAtualizado">Objeto filmeAtualizado com as novas informações</param>
        /// <returns>Um status code</returns>
        [HttpPut]
        public IActionResult PutIdBody(FilmeDomain filmeAtualizado)
        {
            try
            {
                // Cria um objeto generoBuscado que irá receber o gênero buscado no banco de dados
                FilmeDomain filmeBuscado = _filmeRepository.BuscarPorId(filmeAtualizado.IdFilme);

                // Verifica se algum gênero foi encontrado
                if (filmeBuscado != null)
                {
                    // Tenta atualizar o registro
                    try
                    {
                        // Faz a chamada para o método .AtualizarIdCorpo();
                        _filmeRepository.AtualizarIdCorpo(filmeAtualizado);

                        // Retorna um status code 204 - No Content
                        return NoContent();
                    }
                    // Caso ocorra algum erro
                    catch (Exception erro)
                    {
                        // Retorna BadRequest e o erro
                        return BadRequest(erro);
                    }

                }

                // Caso não seja encontrado, retorna NotFound com uma mensagem personalizada
                // e um bool para representar que houve erro
                return NotFound
                    (
                        new
                        {
                            mensagem = "Filme não encontrado",
                            erro = true
                        }
                    );
            }
            catch (Exception erro)
            {

                // Retorna um status 400 - BadRequest e o código do erro
                return BadRequest(erro);
            }

        }

        /// <summary>
        /// Deleta um filme existente
        /// </summary>
        /// <param name="id">id do filme que será deletado</param>
        /// <returns>Um status code 204 - No Content</returns>
        [HttpDelete("{id}")]
        public IActionResult Delete(int id)
        {
            try
            {
                // Faz a chamada para o método .Deletar()
                _filmeRepository.Deletar(id);

                // Retorna um status code 204 - No Content
                return StatusCode(204);
            }
            catch (Exception erro)
            {

                // Retorna um status 400 - BadRequest e o código do erro
                return BadRequest(erro);
            }

        }


        /// <summary>
        /// Atualiza um filme existente passando o seu id pelo corpo da requisição
        /// </summary>
        /// <param name="id">id do filme que será atualizado</param>
        /// <param name="filmeAtualizado">Objeto filmeAtualizado com as novas informações</param>
        /// <returns>Um status code</returns>
        /// http://localhost:5000/api/filme/3
        [HttpPut("{id}")]
        public IActionResult PutIdUrl(int id, FilmeDomain filmeAtualizado)
        {
            try
            {
                // Cria um objeto generoBuscado que irá receber o gênero buscado no banco de dados
                FilmeDomain filmeBuscado = _filmeRepository.BuscarPorId(id);

                // Caso não seja encontrado, retorna NotFound com uma mensagem personalizada
                // e um bool para apresentar que houve erro
                if (filmeBuscado == null)
                {
                    return NotFound
                        (new
                        {
                            mensagem = "Filme não encontrado!",
                            erro = true
                        }
                        );
                }

                // Tenta atualizar o registro
                try
                {
                    // Faz a chamada para o método .AtualizarIdUrl()
                    _filmeRepository.AtualizarIdUrl(id, filmeAtualizado);

                    // Retorna um status code 204 - No Content
                    return NoContent();
                }
                // Caso ocorra algum erro
                catch (Exception erro)
                {
                    // Retorna um status 400 - BadRequest e o código do erro
                    return BadRequest(erro);
                }
            }
            catch (Exception erro)
            {

                // Retorna um status 400 - BadRequest e o código do erro
                return BadRequest(erro);
            }

        }


    }

}

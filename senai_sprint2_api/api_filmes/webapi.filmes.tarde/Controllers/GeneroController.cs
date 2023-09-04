using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;
using webapi.filmes.tarde.Domains;
using webapi.filmes.tarde.Interfaces;
using webapi.filmes.tarde.Repositories;

namespace webapi.filmes.tarde.Controllers
{
    /// <summary>
    /// Define que a rota de uma requisição será no seguinte formato
    /// dominio/api/nomeController
    /// exemplo: http://localhost:5000/api/Genero
    /// </summary>
    [Route("api/[controller]")]
    /// <summary>
    /// Define quem é o controlador da API
    /// </summary>
    [ApiController]
    /// <summary>
    /// Define qual é o tipo de resposta da API
    /// </summary>
    [Produces("application/json")]
    public class GeneroController : ControllerBase
    {
        /// <summary>
        /// Objeto que irá receber os metodos definidos na interface
        /// </summary>
        private IGeneroRepository _generoRepository { get; set; }

        /// <summary>
        /// Instancia do objeto _generoRepository para que haja referencia aos metodos no repositorio 
        /// </summary>
        public GeneroController()
        {
            _generoRepository = new GeneroRepository();
        }


        /// <summary>
        /// EndPoint que acessa um metodo de listar os generos  
        /// </summary>
        /// <returns>Lista de generos e um status code</returns>
        [HttpGet]
        [Authorize]
        
        public IActionResult Get()
        {
            try
            {

                //Cria uma lista para receber os generos
                List<GeneroDomain> ListaGeneros = _generoRepository.ListarTodos();

                //retorna o STATUS CODE 200 OK, junto com a lista de generos no formato JSON
                return Ok(ListaGeneros);

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
                GeneroDomain generoBuscado = _generoRepository.BuscarPorId(id);

                if (generoBuscado == null)
                {
                    return NotFound("O genero buscado não foi encontrado");
                }

                return Ok(generoBuscado);
            }
            catch (Exception erro)
            {
                return BadRequest(erro.Message);
            }
        }




        /// <summary>
        /// Endpoint que acessa o metodo post
        /// </summary>
        /// <param name="novoGenero">Objeto recebido na requisicao</param>
        /// <returns>STATUS CODE</returns>
        [HttpPost]
        public IActionResult Post(GeneroDomain novoGenero)
        {
            try
            {

                // Faz a chamada para o metodo cadastrar passando como paremetro o objeto
                _generoRepository.Cadastrar(novoGenero);

                return StatusCode(201, novoGenero);


            }

            catch (Exception erro)
            {

                //Retorna um status code 400, com uma mensagem de erro
                return BadRequest(erro.Message);
            }

        }



        /// <summary>
        /// Endpoint do metodo atualizar (put) pelo corpo
        /// </summary>
        /// <param name="genero"></param>
        /// <returns></returns>
        [HttpPut]
        public IActionResult PutIdBody(GeneroDomain genero)
        {
            try
            {
                GeneroDomain generoBuscado = _generoRepository.BuscarPorId(genero.IdGenero);



                if (generoBuscado != null)
                {
                    try
                    {
                        _generoRepository.AtualizarIdCorpo(genero);

                        return NoContent();
                    }
                    catch (Exception erro)
                    {

                        return BadRequest(erro.Message);
                    }
                }
                return NotFound("Genero não encontrado!");
            }



            catch (Exception erro)
            {

                return BadRequest(erro.Message);
            }

        }
        /// <summary>
        /// Endpoint do metodo put por url
        /// </summary>
        /// <param name="genero"></param>
        /// <returns></returns>
        [HttpPut("{id}")]
        public IActionResult PutIdUrl(int id, GeneroDomain genero)
        {
            try
            {
                GeneroDomain generoBuscado = _generoRepository.BuscarPorId(id);

                if (generoBuscado != null)
                {
                    try
                    {
                        _generoRepository.AtualizarIdUrl(id, genero);

                        return NoContent();
                    }
                    catch (Exception erro)
                    {

                        return BadRequest(erro.Message);
                    }
                }
                return NotFound("Genero não encontrado!");
            }



            catch (Exception erro)
            {

                return BadRequest(erro.Message);
            }

        }

        /// <summary>
        /// EndPoint que acessa o metodo Delete
        /// </summary>
        /// <param name="id"></param>
        /// <returns>STATUS CODE</returns>
        [HttpDelete("{id}")]
        //[Route("Deletar")]
        public IActionResult Delete(int id)
        {
            try
            {
                _generoRepository.Deletar(id);

                return StatusCode(204, id);
            }
            catch (Exception error)
            {
                return BadRequest(error.Message);
            }
        }


    }
}
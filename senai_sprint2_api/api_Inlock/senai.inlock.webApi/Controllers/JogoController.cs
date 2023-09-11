using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using senai.inlock.webApi_.Domains;
using senai.inlock.webApi_.Interfaces;
using senai.inlock.webApi_.Repositories;
using static System.Runtime.InteropServices.JavaScript.JSType;

namespace senai.inlock.webApi_.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class JogoController : ControllerBase
    {

        private IJogoRepository _jogoRepository { get; set; }

        public JogoController()
        {
            _jogoRepository= new JogoRepository();
        }
        

        /// <summary>
        /// Listar todos os jogos
        /// </summary>
        /// <returns></returns>
        [HttpGet]
        [Authorize]
        public IActionResult Get()
        {
            try
            {

                List<JogoDomain> listaJogos = _jogoRepository.ListarTodos();

                return Ok(listaJogos);

            }
            catch (Exception erro)
            {
                return BadRequest(erro.Message);
            }
        }

        /// <summary>
        /// Listar um jogo por seu id, somente ADM
        /// </summary>
        /// <param name="id">id do jogo</param>
        /// <returns>jogo</returns>
        [HttpGet("{id}")]
        [Authorize(Roles = "2")]
        public IActionResult Get(int id)
        {
            try
            {
                JogoDomain jogoBuscado = _jogoRepository.BuscarPorId(id);

                if (jogoBuscado == null)
                {
                    return NotFound("O jogo buscado não foi encontrado");
                }

                return Ok(jogoBuscado);
            }
            catch (Exception erro)
            {
                return BadRequest(erro.Message);
            }
        }
        /// <summary>
        /// Cadastrar um jogo, somente ADM
        /// </summary>
        /// <param name="novoJogo"></param>
        /// <returns>cadastro de jogo</returns>
        [HttpPost]
        [Authorize(Roles = "2")]

        public IActionResult Post(JogoDomain novoJogo)
        {
            try
            {
                _jogoRepository.Cadastrar(novoJogo);

                return StatusCode(201);
            }
            catch (Exception erro)
            {

                // Retorna um status 400 - BadRequest e o código do erro
                return BadRequest(erro);
            }

        }


    }
}

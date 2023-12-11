using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using Microsoft.Azure.CognitiveServices.ContentModerator;
using Microsoft.EntityFrameworkCore.Metadata;
using System.Drawing.Imaging;
using System.Text;
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
        //Acesso aos metodos do repositorio 
        ComentariosEventoRepository comentario = new ComentariosEventoRepository();

        //Armazena dados da api externa (IA-AZURE)
        private readonly ContentModeratorClient _contentModeratorClient;

        /// <summary>
        /// Construtor que recebe os dados necessarios para o acesso ao serviço externo
        /// </summary>
        /// <param name="contentModeratorClient">Objeto do tipo content moderator </param>
        public ComentariosEventoController (ContentModeratorClient contentModeratorClient)
        {
            _contentModeratorClient = contentModeratorClient;
        }

        [HttpPost("CadastroIA")]
        public async Task<IActionResult> PostIA(ComentariosEvento novoComentario)
        {
            try
            {
                //Se a descrição do comentario não for passada no objeto
                if (string.IsNullOrEmpty(novoComentario.Descricao))
                {
                    return BadRequest("o texto a ser moderado não pode ser vazio");
                }

                //Converte a descricao do comentario em um memory stream
                using var stream = new MemoryStream(Encoding.UTF8.GetBytes(novoComentario.Descricao));

                //Realiza a moderação do conteudo (descricao do comentario)
                var moderationResult = await _contentModeratorClient.TextModeration.ScreenTextAsync("text/plain", stream, "por", false, false, null, true);
               
                //Se existir termos ofensivos sera cadastrado um comentario com o exibe setado em false 
                if (moderationResult.Terms != null)
                {
                    novoComentario.Exibe = false;
                    comentario.Cadastrar(novoComentario);
                }

                else
                {
                    novoComentario.Exibe = true;
                    comentario.Cadastrar(novoComentario);
                }

                return Ok(novoComentario);
            }
            catch (Exception e)
            {
                return BadRequest(e.Message);
            }
        }

        [HttpGet("ListarExibe")]

        public IActionResult GetIA()
        {
            try
            {
                return Ok(comentario.ListarExibe());
            }
            catch (Exception e)
            {
                return BadRequest(e.Message);
                throw;
            }
        }



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

using System.ComponentModel.DataAnnotations;

namespace webapi.filmes.tarde.Domains
{
    /// <summary>
    /// Classe que representa a entidade genero
    /// </summary>
    public class FilmeDomain
    {
        public int IdFilme { get; set; }
        [Required(ErrorMessage = "O titulo do filme é obrigatorio")]
        public string? Titulo { get; set; }
        public int IdGenero { get; set; }
        //Referencia para a classe Genero
        public GeneroDomain? Genero { get; set; }
    }

}

using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace webapi.inlock_codefirst.Domains
{
    [Table("Estudio")]
    public class Estudio
    {
        [Key]
        public Guid IdEstudio { get; set; } = Guid.NewGuid();
        
        [Column(TypeName = "VARCHAR(100)")]
        [Required(ErrorMessage = "Nome Obrigatorio")]
        public string? Nome { get; set; }
        
        //Ref a lista de jogos
        public List<Jogo>? Jogos { get; set; }
    }
}

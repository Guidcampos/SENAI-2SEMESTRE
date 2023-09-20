using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace webapi.inlock_codefirst.Domains
{
    [Table("TiposUsuario")]
    public class TiposUsuario
    {
        [Key]
        public Guid TipoUsuario { get; set; } = Guid.NewGuid();

        [Column(TypeName = "VARCHAR(100)")]
        [Required(ErrorMessage = "o tipo de usuario é obrigatorio")]
        public string? Titulo { get; set; }
    }
}

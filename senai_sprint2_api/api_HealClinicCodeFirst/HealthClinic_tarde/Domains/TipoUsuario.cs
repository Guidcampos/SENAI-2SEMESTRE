using Microsoft.EntityFrameworkCore;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace HealthClinic_tarde.Domains
{
    [Table(nameof(TipoUsuario))]
    [Index(nameof(NomeTipoUsuario), IsUnique = true)]
    public class TipoUsuario
    {
        [Key]

        public Guid IdTipoUsuario { get; set; } = Guid.NewGuid();

        [Column(TypeName = "VARCHAR(20)")]
        [Required(ErrorMessage = "O título do tipo de usuário é obrigatório!")]

        public string? NomeTipoUsuario { get; set; }
    }
}

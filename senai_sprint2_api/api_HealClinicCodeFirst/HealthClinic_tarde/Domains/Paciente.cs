using Microsoft.EntityFrameworkCore;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace HealthClinic_tarde.Domains
{
    [Table(nameof(Paciente))]
    [Index(nameof(CPF), IsUnique = true)]
  
    public class Paciente
    {
        [Key]
        public Guid IdPaciente { get; set; } = Guid.NewGuid();

        [Column(TypeName = "VARCHAR(14)")]
        [Required(ErrorMessage = "O CPF é obrigatorio")]
        [StringLength(14, MinimumLength = 14, ErrorMessage = "O CPF deve conter 14 caracteres")]
        public string CPF { get; set; }

        //CHAVES ESTRANGEIRAS

        [Required(ErrorMessage = "O ID do usuario é obrigatorio")]
        public Guid IdUsuario { get; set; }

        [ForeignKey(nameof(IdUsuario))]
        public Usuario? Usuario { get; set; }

        
    }
}

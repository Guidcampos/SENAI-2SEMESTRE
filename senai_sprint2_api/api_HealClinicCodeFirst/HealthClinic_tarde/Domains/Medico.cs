using Microsoft.EntityFrameworkCore;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace HealthClinic_tarde.Domains
{
    [Table(nameof(Medico))]
    [Index(nameof(CRM), IsUnique= true)]
    public class Medico
    {
        [Key]

        public Guid IdMedico { get; set; } = Guid.NewGuid();

        [Column(TypeName = "VARCHAR(14)")]
        [Required(ErrorMessage = "O CRM é obrigatorio")]
        [StringLength(14, MinimumLength = 14, ErrorMessage = "O CRM deve conter 14 caracteres")]

        public string CRM { get; set; }

        //CHAVES ESTRANGEIRAS
        [Required(ErrorMessage = "O Usuario é obrigatorio ")]
        public Guid IdUsuario { get; set; }

        [ForeignKey(nameof(IdUsuario))]

        public Usuario? Usuario { get; set;}

        [Required(ErrorMessage = "A Especialidade é obrigatoria ")]
        public Guid IdEspecialidade { get; set; }

        [ForeignKey(nameof(IdEspecialidade))]

        public Especialidade? Especialidade { get; set;}

    }
}

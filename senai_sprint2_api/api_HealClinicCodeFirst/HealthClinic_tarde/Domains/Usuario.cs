using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace HealthClinic_tarde.Domains
{
    [Table(nameof(Usuario))]

    public class Usuario
    {
        [Key]

        public Guid IdUsuario { get; set; } = Guid.NewGuid();

        [Column(TypeName = "VARCHAR(100)")]
        [Required(ErrorMessage = "O Nome é obrigatorio")]

        public string? NomeUsuario { get; set; }

        [Column(TypeName = "VARCHAR(100)")]
        [Required(ErrorMessage = "O Email é obrigatorio")]
        [EmailAddress(ErrorMessage = "Digite um email valido")]

        public string EmailUsuario { get; set; }

        [Column(TypeName = "VARCHAR(10)")]
        [Required(ErrorMessage = "A senha é obrigatoria")]
        [StringLength(10, MinimumLength = 6, ErrorMessage = "A senha deve ter entre 6 a 10 caracteres")]

        public string SenhaUsuario { get; set; }

        //CHAVES ESTRANGEIRAS

        [Required(ErrorMessage = "A Clinica é obrigatoria")]

        public Guid IdClinica { get; set; }

        [ForeignKey(nameof(IdClinica))]
        public Clinica Clinica { get; set; }

        [Required(ErrorMessage = "O Tipo de usuario é necessario")]

        public Guid IdTipoUsuario { get; set; }

        [ForeignKey(nameof(IdTipoUsuario))]

        public TipoUsuario TipoUsuario { get; set; }




    }
}

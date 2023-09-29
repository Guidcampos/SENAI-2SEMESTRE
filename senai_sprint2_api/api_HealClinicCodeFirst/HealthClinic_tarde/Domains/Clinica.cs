using Microsoft.EntityFrameworkCore;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace HealthClinic_tarde.Domains
{
    //Clinica = NomeFantasia, Endereco, CNPJ e RazaoSocial

    [Table(nameof(Clinica))]
    [Index(nameof(CNPJ), IsUnique = true)]
    public class Clinica
    {
        [Key]
        public Guid IdClinica { get; set; } = Guid.NewGuid();

        [Column(TypeName = "VARCHAR(30)")]
        [Required(ErrorMessage = "O nome da Clinica é obrigatorio")]

        public string NomeFantasia { get; set; }

        [Column(TypeName = "VARCHAR(100)")]
        [Required(ErrorMessage = "A clinica precisa de um endereço")]

        public string EnderecoClinica { get; set; }

        [Column(TypeName = "CHAR(14)")]
        [Required(ErrorMessage = "CNJP obrigatorio")]
        [StringLength(14, MinimumLength = 14, ErrorMessage = "O CNPJ deve ter 14 caracteres!" )]

        public string CNPJ { get; set; }

        [Column(TypeName = "VARCHAR(30)")]
        [Required(ErrorMessage = "Razao social obrigatoria")]

        public string RazaoSocial { get; set; }



    }

}

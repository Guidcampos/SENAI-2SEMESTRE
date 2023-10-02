using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace HealthClinic_tarde.Domains
{
    [Table(nameof(Prontuario))]

    public class Prontuario
    {
        [Key]
        public Guid IdProntuario { get; set; }

        [Column(TypeName = "VARCHAR(100)")]
        [Required(ErrorMessage = "A descricao do prontuario é obrigatoria")]

        public string Descricao { get; set; }

        //CHAVES ESTRANGEIRAS
        [Required(ErrorMessage = "O Id da Consulta é obrigatorio")]
        public Guid IdConsulta { get; set; }
        [ForeignKey(nameof(IdConsulta))]

        public Consulta? Consulta { get; set; }
        
      

      

    }
}

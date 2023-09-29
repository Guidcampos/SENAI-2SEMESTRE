using Microsoft.EntityFrameworkCore.Metadata.Internal;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace HealthClinic_tarde.Domains
{
    [Table(nameof(Consulta))]

    public class Consulta
    {
        [Key]

        public Guid IdConsulta { get; set; } = Guid.NewGuid();

        [Column(TypeName = "DATE")]
        [Required(ErrorMessage = "A data da consulta é obrigatoria")]
        public DateTime DataConsulta { get; set; }

        //CHAVES ESTRANGEIRAS
        [Required(ErrorMessage = "A clinica é obrigatoria")]
        public Guid IdClinica { get; set; }

        [ForeignKey(nameof(IdClinica))]
        public Clinica? Clinica { get; set; }


        [Required(ErrorMessage = "O Medico é obrigatorio")]
        public Guid IdMedico { get; set; }

        [ForeignKey(nameof(IdMedico))]
        public Medico? Medico { get; set; }
        
        
        [Required(ErrorMessage = "O Paciente é obrigatorio")]
        public Guid IdPaciente { get; set; }

        [ForeignKey(nameof(IdPaciente))]
        public Paciente? Paciente { get; set; }



    }
}

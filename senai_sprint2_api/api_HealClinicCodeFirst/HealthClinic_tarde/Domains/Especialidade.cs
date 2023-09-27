using Microsoft.EntityFrameworkCore;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace HealthClinic_tarde.Domains
{
    [Table(nameof(Especialidade))]
    [Index(nameof(TituloEspecialidade), IsUnique = true)]
    public class Especialidade
    {
        [Key]
        public Guid IdEspecialidade { get; set; } = Guid.NewGuid();

        [Column(TypeName = "VARCHAR(20)")]
        [Required(ErrorMessage = "Especialidade necessaria")]

        public string TituloEspecialidade { get; set; }
    }
}

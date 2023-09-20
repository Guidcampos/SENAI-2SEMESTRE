using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace webapi.inlock_codefirst.Domains
{
    [Table("Jogo")]
    public class Jogo
    {
        [Key]

        public Guid IdJogo { get; set; } = Guid.NewGuid();
        
        [Column(TypeName = "VARCHAR(100)")]
        [Required(ErrorMessage = "Nome obrigatorio ")]
        
        public string? Nome{ get; set; }
        
        [Column(TypeName = "TEXT")]
        [Required(ErrorMessage = "Descriçao obrigatorio ")]
        public string? Descricao { get; set; }

        [Column(TypeName = "DATE")]
        [Required(ErrorMessage = "Data Obrigatoria ")]
        public DateTime DataLancamento { get; set; }


        [Column(TypeName = "DECIMAL(4,2)")]

        [Required(ErrorMessage = "Preço obrigatorio ")]
        public decimal Preco { get; set; }

        //Referencia da foreignkey
        public Guid IdEstudio { get; set; }

        [ForeignKey("IdEstudio")]
        public Estudio? Estudio { get; set; }
    }
}

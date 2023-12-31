﻿using Microsoft.EntityFrameworkCore;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace webapi.inlock_codefirst.Domains
{
    [Table("Usuario")]
    public class Usuario
    {
        [Key]
        public Guid IdUsuario { get; set; } = Guid.NewGuid();
        
        [Column(TypeName = "VARCHAR(100)")]
        [Required(ErrorMessage = "Email obrigatorio")]
        
        public string? Email { get; set; }
        
        [Column(TypeName = "VARCHAR(100)")]
        [Required(ErrorMessage = "Senha obrigatorio")]
        [StringLength(20, MinimumLength = 6, ErrorMessage = "Senha deve ter entre 6 e 20 caracteres")]
      
        public string? Senha { get; set; }


    }

}

using System.ComponentModel.DataAnnotations;

namespace HealthClinic_tarde.ViewModels
{
    public class LoginViewModel
    {
        [Required(ErrorMessage = "Email obrigatorio")]

        public string Email { get; set; }
        [Required(ErrorMessage = "Senha obrigatória!")]

        public string Senha { get; set; }
    }
}

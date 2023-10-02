using HealthClinic_tarde.Domains;
using HealthClinic_tarde.Interfaces;
using HealthClinic_tarde.Repositories;
using HealthClinic_tarde.ViewModels;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using Microsoft.IdentityModel.Tokens;
using System.IdentityModel.Tokens.Jwt;
using System.Security.Claims;

namespace HealthClinic_tarde.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    [Produces("application/json")]
    public class LoginController : ControllerBase
    {
        private readonly IUsuarioRepository _usuarioRepository;
        public LoginController()
        {
            _usuarioRepository = new UsuarioRepository();
        }

        [HttpPost]
        public IActionResult Login(LoginViewModel usuario)
        {
            try
            {
                Usuario usuarioBuscado = _usuarioRepository.BuscarEmailSenha(usuario.Email!, usuario.Senha!);

                if (usuarioBuscado == null) return StatusCode(401, "Email ou senha inválidos!");

                var claims = new[]
                    {
                    new Claim(JwtRegisteredClaimNames.Jti, usuarioBuscado.IdUsuario.ToString()),
                    new Claim(JwtRegisteredClaimNames.Email, usuarioBuscado.EmailUsuario!),
                    new Claim(JwtRegisteredClaimNames.Name, usuarioBuscado.NomeUsuario!),
                    new Claim(ClaimTypes.Role, usuarioBuscado.TipoUsuario!.NomeTipoUsuario!),
                    };

                var key = new SymmetricSecurityKey(System.Text.Encoding.UTF8.GetBytes("healthclinic-chave-autenticacao-webapi"));

                var creds = new SigningCredentials(key, SecurityAlgorithms.HmacSha256);

                var token = new JwtSecurityToken
                    (
                    issuer: "healthclinic.tarde",
                    audience: "healthclinic.tarde",
                    claims: claims,
                    expires: DateTime.Now.AddMinutes(5),
                    signingCredentials: creds
                    );

                return Ok(new
                {
                    token = new JwtSecurityTokenHandler().WriteToken(token),

                });
            }
            catch (Exception erro)
            {
                return BadRequest(erro.Message);
            }
        }
    }
}

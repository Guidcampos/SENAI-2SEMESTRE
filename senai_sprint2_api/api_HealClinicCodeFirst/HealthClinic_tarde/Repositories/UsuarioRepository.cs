using HealthClinic_tarde.Contexts;
using HealthClinic_tarde.Domains;
using HealthClinic_tarde.Interfaces;
using HealthClinic_tarde.Utils;

namespace HealthClinic_tarde.Repositories
{
    public class UsuarioRepository : IUsuarioRepository
    {
        private readonly HealthContext _healthcontext;

        public UsuarioRepository() 
        { 
            _healthcontext = new HealthContext();
        }

        public Usuario BuscarEmailSenha(string email, string senha)
        {
            try
            {
                Usuario usuarioBuscado = _healthcontext.Usuario.Select(a => new Usuario
                {
                    IdUsuario = a.IdUsuario,
                    NomeUsuario = a.NomeUsuario,
                    EmailUsuario = a.EmailUsuario,
                    SenhaUsuario = a.SenhaUsuario,
                    TipoUsuario = new TipoUsuario
                    {
                        IdTipoUsuario = a.IdTipoUsuario,
                        NomeTipoUsuario = a.TipoUsuario!.NomeTipoUsuario
                    }

                   
                    
                }).FirstOrDefault(r => r.EmailUsuario == email)!;

                if (usuarioBuscado != null)
                {
                    bool confere = Criptografia.CompararHash(senha, usuarioBuscado.SenhaUsuario!);
                    if (confere)
                    {
                        return usuarioBuscado;
                    }
                   
                } return null!;
            }
            catch (Exception)
            {

                throw;
            }
        }

        public Usuario BuscarId(Guid id)
        {
            try
            {
                Usuario usuarioBuscado = _healthcontext.Usuario.FirstOrDefault(a => a.IdUsuario == id)!;
                return usuarioBuscado;
            }
            catch (Exception)
            {

                throw;
            }
        }

        public void Cadastrar(Usuario novoUsuario)
        {
            try
            {

                 novoUsuario.SenhaUsuario = Criptografia.GerarHash(novoUsuario.SenhaUsuario!);
                _healthcontext.Usuario.Add(novoUsuario);
                _healthcontext.SaveChanges();

            }
            catch (Exception)
            {

                throw;
            }
        }

        public List<Usuario> Listar()
        {
            
              return  _healthcontext.Usuario.ToList();
            
        }
    }
}

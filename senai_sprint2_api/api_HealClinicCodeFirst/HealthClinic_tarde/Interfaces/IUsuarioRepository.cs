using HealthClinic_tarde.Domains;

namespace HealthClinic_tarde.Interfaces
{
    public interface IUsuarioRepository
    {
        void Cadastrar(Usuario usuario);

        Usuario BuscarId(Guid id);

        Usuario BuscarEmailSenha(string email, string senha);

        List<Usuario> Listar();

        
    }
}

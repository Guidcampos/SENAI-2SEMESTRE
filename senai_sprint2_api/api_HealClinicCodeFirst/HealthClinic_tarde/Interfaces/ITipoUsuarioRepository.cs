using HealthClinic_tarde.Domains;

namespace HealthClinic_tarde.Interfaces
{
    public interface ITipoUsuarioRepository
    {
        void Cadastrar(TipoUsuario tipoUsuario);

        List<TipoUsuario> Listar();
    }
}

using HealthClinic_tarde.Domains;

namespace HealthClinic_tarde.Interfaces
{
    public interface IProntuarioRepository
    {

        void Cadastrar(Prontuario prontuario);

        void Deletar(Guid id);

        List<Prontuario> Listar();

        Prontuario BuscarPorId(Guid id);

        void Atualizar(Guid id, Prontuario prontuario);
    }
}

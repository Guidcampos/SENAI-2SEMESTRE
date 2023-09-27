using HealthClinic_tarde.Domains;

namespace HealthClinic_tarde.Interfaces
{
    public interface IProntuarioRepository
    {

        void Cadastrar(Clinica clinica);

        void Deletar(Guid id);

        List<Clinica> Listar();

        Clinica BuscarPorId(Guid id);

        void Atualizar(Guid id, Clinica clinica);
    }
}

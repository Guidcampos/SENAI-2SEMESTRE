using HealthClinic_tarde.Domains;

namespace HealthClinic_tarde.Interfaces
{
    public interface IMedicoRepository
    {

        void Cadastrar(Medico medico);

        void Deletar(Guid id);

        List<Medico> Listar();

        Medico BuscarPorId(Guid id);

        void Atualizar(Guid id, Medico medico);
    }
}

using HealthClinic_tarde.Domains;

namespace HealthClinic_tarde.Interfaces
{
    public interface IConsultaRepository
    {
        void Cadastrar(Consulta consulta);

        void Deletar(Guid id);

        List<Consulta> Listar();

        Consulta BuscarPorId(Guid id);

        void Atualizar(Guid id, Consulta consulta);
    }
}

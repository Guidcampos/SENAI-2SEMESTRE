using senai.inlock.webApi_.Domains;

namespace senai.inlock.webApi_.Interfaces
{
    public interface IEstudioRepository
    {
        //Crud de estudio, necessarios para entregar

        List<EstudioDomain> ListarTodos();

        EstudioDomain BuscarPorId(int id);
    }
}

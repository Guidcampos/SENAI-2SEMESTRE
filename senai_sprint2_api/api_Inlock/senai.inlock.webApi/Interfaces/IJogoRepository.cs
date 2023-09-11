using senai.inlock.webApi_.Domains;

namespace senai.inlock.webApi_.Interfaces
{
    public interface IJogoRepository
    {
        //Crud de jogos necessarios para entregar

        void Cadastrar(JogoDomain novoJogo);

        List<JogoDomain> ListarTodos();

        JogoDomain BuscarPorId(int id);

        void Deletar(int id);

    }
}

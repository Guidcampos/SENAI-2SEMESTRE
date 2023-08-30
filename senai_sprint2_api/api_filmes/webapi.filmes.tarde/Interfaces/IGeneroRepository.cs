using webapi.filmes.tarde.Domains;

namespace webapi.filmes.tarde.Interfaces
{
    /// <summary>
    /// Interface responsavel pelo repositorio GeneroRepository, Define os metodos que serao implementados
    ///
    /// </summary>
    public interface IGeneroRepository
    {
        //CRUD  
        //TipoDeRetorno NomeMetodo (TipoParametro NomeParametro)
        /// <summary>
        /// Metodo responsavel por cadastrar novo genero
        /// </summary>
        /// <param name="novoGenero">Objeto que será cadastrado</param>
        void Cadastrar(GeneroDomain novoGenero);
        
        /// <summary>
        /// Retorna todoos generos cadastrados
        /// </summary>
        /// <returns>Uma lista de generos</returns>
        List<GeneroDomain> ListarTodos();

        /// <summary>
        /// Buscar objeto atravez do seu id
        /// </summary>
        /// <param name="id">Id do objeto a ser buscado</param>
        /// <returns>Objeto que foi buscado</returns>
        GeneroDomain BuscarPorId(int id);
        
        
        /// <summary>
        /// Atualiza um genero existente passando o id pelo corpo da requisição
        /// </summary>
        /// <param name="genero">Objeto com as novas informações</param>
        void AtualizarIdCorpo(GeneroDomain genero);



        /// <summary>
        /// Atualizar um genero existente, passando o id pela URL
        /// </summary>
        /// <param name="id">ID do objeto a ser atualizado</param>
        /// <param name="genero">Objeto com as novas informações</param>
        void AtualizarIdUrl(int id, GeneroDomain genero);
        
        /// <summary>
        /// Deleta um genero existente
        /// </summary>
        /// <param name="id">Id do objeto a ser deletado</param>
        void Deletar(int id);
    }


}

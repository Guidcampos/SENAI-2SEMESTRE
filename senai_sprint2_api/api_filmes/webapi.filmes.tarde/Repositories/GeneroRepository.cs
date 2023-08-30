using System.Data.SqlClient;
using webapi.filmes.tarde.Domains;
using webapi.filmes.tarde.Interfaces;

namespace webapi.filmes.tarde.Repositories
{
    public class GeneroRepository : IGeneroRepository
    {
        /// <summary>
        /// String de conexão com o banco de dados que recebe os seguintes parâmetros:
        /// Data Source: Nome do servidor do banco
        /// Initial Catalog: Nome do banco de dados
        /// Autenticação:
        ///     - Windows: Integrated Security = True
        ///     - SqlServer: User Id = sa; Pwd = Senha
        /// </summary>
        private string StringConexao = "Data Source = NOTE10-S15; Initial Catalog = Filmes_Tarde; User Id = sa; Pwd = Senai@134";
        
        /// <summary>
        /// Atualiza o id pelo corpo
        /// </summary>
        /// <param name="genero"></param>
        public void AtualizarIdCorpo(GeneroDomain genero)
        {
            using (SqlConnection con = new SqlConnection(StringConexao))
            {
                string queryUpdateBody = "UPDATE Genero SET Nome = @Nome WHERE IdGenero = @IdGenero";

                con.Open();

                using(SqlCommand cmd = new SqlCommand(queryUpdateBody,con)) 
                {
                    cmd.Parameters.AddWithValue("@Nome", genero.Nome);
                    cmd.Parameters.AddWithValue("@IdGenero", genero.IdGenero);

                    cmd.ExecuteNonQuery();
                
                }
            
            }
           
        }

        public void AtualizarIdUrl(int id, GeneroDomain genero)
        {
            using (SqlConnection con = new SqlConnection(StringConexao))
            { 
                string queryUpdateUrl = "UPDATE Genero SET Nome = @Nome WHERE IdGenero = @IdGenero";

                con.Open();

                using (SqlCommand cmd = new SqlCommand (queryUpdateUrl, con))
                {
                    cmd.Parameters.AddWithValue("@Nome", genero.Nome);
                    cmd.Parameters.AddWithValue("@IdGenero", id);

                    cmd.ExecuteNonQuery();

                }
          
            
            }


        }

        public GeneroDomain BuscarPorId(int id)
        {
            //Cria uma lista de gêneros para armazená-los
            GeneroDomain generoBuscado = new();

            //Declara a SqlConnection passando a String de Conexão como parâmetro
            using (SqlConnection con = new(StringConexao))
            {
                //Declara a instrução a ser executada
                string queryFindById = $"SELECT IdGenero, Nome FROM Genero WHERE IdGenero = {id}";

                //Abre a conexão com o banco de dados
                con.Open();

                //Declara o SqlDataReader para percorrer (ler) a tabela no banco de dados
                SqlDataReader rdr;

                //Declara o SqlCommand passando a query que será executada e a conexão
                using SqlCommand cmd = new(queryFindById, con);
                //Executa a query e armazena os dados no rdr
                rdr = cmd.ExecuteReader();

                //Enquanto houver registros para serem lidos no rdr, o laço se repetirá.
                if (rdr.Read())
                {
                    generoBuscado = new()
                    {
                        //Atribui à propriedade IdGenero o valor da primeira coluna
                        IdGenero = Convert.ToInt32(rdr["IdGenero"]),
                        //Atribui à propriedade IdGenero o valor da primeira coluna
                        Nome = rdr[1].ToString(),
                    };

                };
            };

            //Retorna a lista de gêneros
            return generoBuscado;
        }

        /// <summary>
        /// Cadastrar novo genero
        /// </summary>
        /// <param name="novoGenero">Objeto com as informaçoes que serão cadastradas</param>

        public void Cadastrar(GeneroDomain novoGenero)
        {
            // Declara a SqlConnection passando a string de conexão como parâmetro
            using (SqlConnection con = new SqlConnection(StringConexao))
            {
                // Declara a instrução a ser executada passando como valor do nome o objeto
                string queryInsert = "INSERT INTO Genero(Nome) VALUES ('"+ novoGenero.Nome +"')";

                con.Open();

                using (SqlCommand cmd = new SqlCommand(queryInsert,con)) 
                {
                    //executa a querry
                    cmd.ExecuteNonQuery();             
                
                }
            
            }
        }

        public void Deletar(int id)
        {
            using (SqlConnection con = new SqlConnection(StringConexao))
            {
                string queryDelete = $"DELETE FROM Genero WHERE Genero.IdGenero LIKE {id}";
                con.Open();

                using (SqlCommand cmd = new SqlCommand(queryDelete, con))
                { 
                    cmd.ExecuteNonQuery();
                }
            }

            
        }

        /// <summary>
        /// Listar todos os objetos do tipo Gênero
        /// </summary>
        /// <returns>Lista de objetos do tipo Gênero</returns>
        public List<GeneroDomain> ListarTodos()
        {
            // Cria uma lista de gêneros onde os gêneros serão armazenados
            List<GeneroDomain> listaGeneros = new List<GeneroDomain>();

            // Declara a SqlConnection passando a string de conexão como parâmetro
            using (SqlConnection con = new SqlConnection(StringConexao))
            {
                // Declara a instrução a ser executada
                string querySelectAll = "SELECT IdGenero, Nome FROM Genero";

                // Abre a conexão com o banco de dados
                con.Open();

                // Declara o SqlDataReader para percorrer(ler) a tabela no banco de dados
                SqlDataReader rdr;

                // Declara o SqlCommand passando a query que será executada e a conexão
                using (SqlCommand cmd = new SqlCommand(querySelectAll, con))
                {
                    // Executa a query e armazena os dados no rdr
                    rdr = cmd.ExecuteReader();

                    // Enquanto houver registros para serem lidos no rdr, o laço se repetirá
                    while (rdr.Read())
                    {
                        GeneroDomain genero = new GeneroDomain()
                        {
                            // Atribui a propriedade IdGenero o valor da primeira coluna da tabela
                            IdGenero = Convert.ToInt32(rdr[0]),
                            Nome = rdr["Nome"].ToString(),
                        };
                        listaGeneros.Add(genero);
                    }
                }
            }
            return listaGeneros;
        }
    }
}

using System.Data.SqlClient;
using webapi.filmes.tarde.Domains;
using webapi.filmes.tarde.Interfaces;

namespace webapi.filmes.tarde.Repositories
{
    public class FilmeRepository : IFilmeRepository
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


        public void AtualizarIdCorpo(FilmeDomain filme)
        {

            using (SqlConnection con = new SqlConnection(StringConexao))
            {
                string queryUpdate = "UPDATE Filme SET Titulo = '@TituloInserir', IdGenero = @IdGeneroInserir WHERE IdFilme = @IdFilme";

                using (SqlCommand cmd = new SqlCommand(queryUpdate, con))
                {
                    cmd.Parameters.AddWithValue("@TituloInserir", filme.Titulo);
                    cmd.Parameters.AddWithValue("@IdGeneroInserir", filme.IdGenero);
                    cmd.Parameters.AddWithValue("@IdFilme", filme.IdFilme);

                    con.Open();

                    cmd.ExecuteNonQuery();
                }
            }
        }

        public void AtualizarIdUrl(int id, FilmeDomain filme)
        {
            using (SqlConnection con = new SqlConnection(StringConexao))
            {
                string queryUpdateUrl = "UPDATE Filme SET Titulo = '@TituloInserir', IdGenero = @IdGeneroInserir WHERE IdFilme = @IdFilme";

                con.Open();

                using (SqlCommand cmd = new SqlCommand(queryUpdateUrl, con))
                {
                    cmd.Parameters.AddWithValue("@Titulo", filme.Titulo);
                    cmd.Parameters.AddWithValue("@IdGeneroInserir", filme.IdGenero);
                    cmd.Parameters.AddWithValue("@IdFilme", id);

                    cmd.ExecuteNonQuery();

                }


            }

        }

        public FilmeDomain BuscarPorId(int id)
        {
            FilmeDomain filmeBuscado = new FilmeDomain();

            using (SqlConnection con = new SqlConnection(StringConexao))
            {
                // string querySelectFilme = "SELECT IdFilme, IdGenero, Titulo FROM Filme WHERE IdFilme = @IdFilme";

                string querySelectFilme = "SELECT IdFilme, Filme.IdGenero, Titulo, Genero.Nome FROM Filme inner join Genero on Filme.IdGenero = Genero.IdGenero Where IdFilme = @IdFilme";

                con.Open();

                using (SqlCommand cmd = new SqlCommand(querySelectFilme, con))
                {
                    cmd.Parameters.AddWithValue("@IdFilme", id);

                    using (SqlDataReader rdr = cmd.ExecuteReader())
                    {
                        if (rdr.Read())
                        {
                            filmeBuscado = new FilmeDomain()
                            {
                                IdFilme = Convert.ToInt32(rdr["IdFilme"]),
                                IdGenero = Convert.ToInt32(rdr["IdGenero"]),
                                Titulo = rdr["Titulo"].ToString(),

                                Genero = new GeneroDomain() 
                                { 
                                    IdGenero = Convert.ToInt32(rdr["IdGenero"]),
                                    Nome = rdr["Nome"].ToString(),
                                }
                            };
                        }
                    }
                }
            }
            return filmeBuscado;
        }

        public void Cadastrar(FilmeDomain novoFilme)
        {

            // Declara a SqlConnection passando a string de conexão como parâmetro
            using (SqlConnection con = new SqlConnection(StringConexao))
            {
                // Declara a instrução a ser executada passando como valor do nome o objeto
                string queryInsert = "INSERT INTO Filme (IdGenero, Titulo) VALUES (@IdGenero, '@Titulo')";

                con.Open();

                using (SqlCommand cmd = new SqlCommand(queryInsert, con))
                {
                    cmd.Parameters.AddWithValue("@IdGenero", novoFilme.IdGenero);
                    cmd.Parameters.AddWithValue("@Titulo", novoFilme.Titulo);
                    //executa a querry
                    cmd.ExecuteNonQuery();

                }

            }
        }

        public void Deletar(int id)
        {
            using (SqlConnection con = new SqlConnection(StringConexao))
            {
                string queryDelete = $"DELETE FROM Filme WHERE IdFilme = {id}";
                con.Open();

                using (SqlCommand cmd = new SqlCommand(queryDelete, con))
                {
                    cmd.ExecuteNonQuery();
                }
            }

        }

        public List<FilmeDomain> ListarTodos()
        {

            // Cria uma lista de gêneros onde os gêneros serão armazenados
            List<FilmeDomain> listaFilmes = new List<FilmeDomain>();

            // Declara a SqlConnection passando a string de conexão como parâmetro
            using (SqlConnection con = new SqlConnection(StringConexao))
            {
                // Declara a instrução a ser executada
                string querySelectAll = "Select Filme.IdFilme,Filme.IdGenero, Genero.Nome AS Genero, Titulo From Filme Inner Join Genero ON  Genero.IdGenero = Filme.IdGenero";

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
                        FilmeDomain filme = new FilmeDomain()
                        {
                            // Atribui a propriedade IdGenero o valor da primeira coluna da tabela
                            IdFilme = Convert.ToInt32(rdr[0]),
                            IdGenero = Convert.ToInt32(rdr[1]),
                            Titulo = rdr[3].ToString(),

                            Genero = new GeneroDomain()
                            {
                                IdGenero = Convert.ToInt32(rdr[1]),
                                Nome = rdr[2].ToString(),
                            }
                        };
                        listaFilmes.Add(filme);
                    }
                }
            }
            return listaFilmes;
        }
    }
}
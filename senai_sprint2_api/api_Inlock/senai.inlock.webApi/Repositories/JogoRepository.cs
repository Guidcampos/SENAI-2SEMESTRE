using senai.inlock.webApi_.Domains;
using senai.inlock.webApi_.Interfaces;
using System.Data.SqlClient;
using System.Reflection.Metadata.Ecma335;

namespace senai.inlock.webApi_.Repositories
{
    public class JogoRepository : IJogoRepository
    {

        private string StringConexao = "Data Source = NOTE10-S15; Initial Catalog = inlock_games_Tarde; User Id = sa; Pwd = Senai@134";
        public JogoDomain BuscarPorId(int id)
        {

            JogoDomain jogoBuscado = new JogoDomain();

            using (SqlConnection con = new SqlConnection(StringConexao))
            {
                string querySelectJogo = "SELECT Jogo.IdJogo,Jogo.IdEstudio, Estudio.Nome, Jogo.Nome AS JogoNome, Jogo.Descricao, Jogo.DataLancamento, Jogo.Valor FROM Jogo inner join Estudio ON Jogo.IdEstudio = Estudio.IdEstudio Where IdJogo = @IdJogo";

                con.Open();

                using (SqlCommand cmd = new SqlCommand(querySelectJogo, con))
                {
                    cmd.Parameters.AddWithValue("@IdJogo", id);

                    using (SqlDataReader rdr = cmd.ExecuteReader())
                    {
                        if (rdr.Read())
                        {
                            jogoBuscado = new JogoDomain()
                            {
                                IdJogo = Convert.ToInt32(rdr["IdJogo"]),
                                IdEstudio = Convert.ToInt32(rdr["IdEstudio"]),
                                Nome = rdr["JogoNome"].ToString(),
                                Descricao = rdr["Descricao"].ToString(),
                                Valor = Convert.ToInt32(rdr["Valor"]),
                                DataLanc = Convert.ToDateTime(rdr["DataLancamento"]),

                                Estudio = new EstudioDomain()
                                {
                                    IdEstudio = Convert.ToInt32(rdr["IdEstudio"]),
                                    Nome = rdr["Nome"].ToString(),
                                }
                            };
                        }
                    }

                }

            }
            return jogoBuscado;

        }

        public void Cadastrar(JogoDomain novoJogo)
        {
            using (SqlConnection con = new SqlConnection(StringConexao))
            {
                string queryInsertJogo = "INSERT INTO Jogo (IdEstudio, Nome, Descricao, DataLancamento, Valor) VALUES (@IdEstudio, @Nome, @Descricao, @DataLancamento, @Valor)";

                con.Open();

                using (SqlCommand cmd = new SqlCommand(queryInsertJogo, con))
                {
                    cmd.Parameters.AddWithValue("@IdEstudio", novoJogo.IdEstudio);
                    cmd.Parameters.AddWithValue("@Nome", novoJogo.Nome);
                    cmd.Parameters.AddWithValue("@Descricao", novoJogo.Descricao);
                    cmd.Parameters.AddWithValue("@DataLancamento", novoJogo.DataLanc);
                    cmd.Parameters.AddWithValue("@Valor", novoJogo.Valor);

                    cmd.ExecuteNonQuery();
                }
            }
        }

        public void Deletar(int id)
        {
            throw new NotImplementedException();
        }

        public List<JogoDomain> ListarTodos()
        {
            List<JogoDomain> listaJogos = new List<JogoDomain>();

            using (SqlConnection con = new SqlConnection(StringConexao))
            {
                string querySelectAll = "SELECT Jogo.IdJogo,Jogo.IdEstudio, Estudio.Nome, Jogo.Nome AS JogoNome, Jogo.Descricao, Jogo.DataLancamento, Jogo.Valor FROM Jogo inner join Estudio ON Jogo.IdEstudio = Estudio.IdEstudio";

                con.Open();

                SqlDataReader rdr;

                using (SqlCommand cmd = new SqlCommand(querySelectAll, con))
                {
                    rdr = cmd.ExecuteReader();

                    while (rdr.Read())
                    {
                        JogoDomain jogo = new JogoDomain()
                        {
                            IdJogo = Convert.ToInt32(rdr["IdJogo"]),
                            IdEstudio = Convert.ToInt32(rdr["IdEstudio"]),
                            Nome = rdr["JogoNome"].ToString(),
                            Descricao = rdr["Descricao"].ToString(),
                            Valor = Convert.ToInt32(rdr["Valor"]),
                            DataLanc = Convert.ToDateTime(rdr["DataLancamento"]),

                            Estudio = new EstudioDomain()
                            {
                                IdEstudio = Convert.ToInt32(rdr["IdEstudio"]),
                                Nome = rdr["Nome"].ToString(),
                            }
                        };
                        listaJogos.Add(jogo);

                    };

                }
            }

            return listaJogos;
        }

    }
}




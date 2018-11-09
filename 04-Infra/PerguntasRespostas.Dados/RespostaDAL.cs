using System;
using System.Collections.Generic;
using System.Text;
using System.Linq;
using System.Threading.Tasks;

using System.Data.SqlClient;

using System.Data;
using PerguntasRespostas.Entidades;
using PerguntasRespostas.Dados;

namespace RespostasRespostas.Dados
{
    public class RespostaDAL
    {
        private string connectionString = new DBConfiguration().GetconfigurationStringSQL();
        
        public IEnumerable<Resposta> GetResposta()
        {
            List<Resposta> ListaObj = new List<Resposta>();

            SqlConnection con = new SqlConnection(connectionString);

            try

            {
                con.Open();

                SqlCommand cmd = new SqlCommand("PR_GetResposta", con);

                cmd.CommandType = CommandType.StoredProcedure;

                SqlDataReader dr = cmd.ExecuteReader();

                while (dr.Read())

                {

                    Resposta obj = new Resposta();

                    obj.Id = dr["Id"].ToString().Equals(string.Empty) ? 0 : Convert.ToInt32(dr["Id"].ToString());

                    obj.IdPergunta = dr["IdPergunta"].ToString().Equals(string.Empty) ? 0 : Convert.ToInt32(dr["IdPergunta"].ToString());

                    obj.IdAutor = dr["IdAutor"].ToString().Equals(string.Empty) ? 0 : Convert.ToInt32(dr["IdAutor"].ToString());
                    
                    obj.Descricao = dr["Descricao"].ToString();

                    obj.Ativo = dr["Ativo"].ToString().Equals(string.Empty) ? false : Convert.ToBoolean(dr["Ativo"].ToString());

                    obj.RespostaAceita = dr["RespostaAceita"].ToString().Equals(string.Empty) ? false : Convert.ToBoolean(dr["RespostaAceita"].ToString());

                    obj.DataCriacao = dr["DataCriacao"].ToString().Equals(string.Empty) ? DateTime.MinValue : Convert.ToDateTime(dr["DataCriacao"].ToString());
                    

                    ListaObj.Add(obj);

                }
                               
                return ListaObj;

            }

            catch (Exception ex)

            {

                throw ex;

            }

            finally

            {

                con.Close();

            }
        }

        public Resposta GetResposta(int id)
        {
            SqlConnection con = new SqlConnection(connectionString);

            try

            {
                con.Open();

                SqlCommand cmd = new SqlCommand("PR_GetResposta", con);

                cmd.CommandType = CommandType.StoredProcedure;

                cmd.Parameters.AddWithValue("@Id", id);

                SqlDataReader dr = cmd.ExecuteReader();

                Resposta obj = new Resposta();

                while (dr.Read())

                {                    

                    obj.Id = dr["Id"].ToString().Equals(string.Empty) ? 0 : Convert.ToInt32(dr["Id"].ToString());

                    obj.Descricao = dr["Descricao"].ToString();

                    obj.IdAutor = dr["IdAutor"].ToString().Equals(string.Empty) ? 0 : Convert.ToInt32(dr["IdAutor"].ToString());

                    obj.IdPergunta = dr["IdPergunta"].ToString().Equals(string.Empty) ? 0 : Convert.ToInt32(dr["IdPergunta"].ToString());
                    
                    obj.Ativo = dr["Ativo"].ToString().Equals(string.Empty) ? false : Convert.ToBoolean(dr["Ativo"].ToString());

                    obj.RespostaAceita = dr["RespostaAceita"].ToString().Equals(string.Empty) ? false : Convert.ToBoolean(dr["RespostaAceita"].ToString());

                    obj.DataCriacao = dr["DataCriacao"].ToString().Equals(string.Empty) ? DateTime.MinValue : Convert.ToDateTime(dr["DataCriacao"].ToString());

                }

                return obj;

            }

            catch (Exception ex)

            {

                throw ex;

            }

            finally

            {

                con.Close();

            }
        }

        public bool PutResposta(int id, Resposta Resposta)
        {
            SqlConnection con = new SqlConnection(connectionString);

            try

            {

                con.Open();

                SqlCommand cmd = new SqlCommand("PR_PutResposta", con);

                cmd.CommandType = CommandType.StoredProcedure;
                               
                cmd.Parameters.AddWithValue("@id", id);

                cmd.Parameters.AddWithValue("@IdPergunta", Resposta.IdPergunta);

                cmd.Parameters.AddWithValue("@IdAutor", Resposta.IdAutor);
                
                cmd.Parameters.AddWithValue("@Descricao", Resposta.Descricao);
                              
                cmd.Parameters.AddWithValue("@Ativo", Resposta.Ativo);

                cmd.Parameters.AddWithValue("@RespostaAceita", Resposta.RespostaAceita);

                cmd.Parameters.AddWithValue("@DataCriacao", Resposta.DataCriacao);

                return cmd.ExecuteNonQuery() != 0 ? true : false;


            }

            catch (Exception ex)

            {

                throw ex;  // retorna mensagem de erro

            }

            finally

            {

                con.Close();

            }
        }

        public bool PostResposta(Resposta Resposta)
        {
            SqlConnection con = new SqlConnection(connectionString);

            try

            {
                con.Open();

                SqlCommand cmd = new SqlCommand("PR_PostResposta", con);

                cmd.CommandType = CommandType.StoredProcedure;

                cmd.Parameters.AddWithValue("@IdPergunta", Resposta.IdPergunta);

                cmd.Parameters.AddWithValue("@IdAutor", Resposta.IdAutor);

                cmd.Parameters.AddWithValue("@Descricao", Resposta.Descricao);

                cmd.Parameters.AddWithValue("@Ativo", Resposta.Ativo);

                cmd.Parameters.AddWithValue("@RespostaAceita", Resposta.RespostaAceita);

                cmd.Parameters.AddWithValue("@DataCriacao", Resposta.DataCriacao);

                return cmd.ExecuteNonQuery() != 0 ? true : false;
                
            }

            catch (Exception ex)

            {

                throw ex;  // retorna mensagem de erro

            }

            finally

            {

                con.Close();

            }
        }       

        public bool DeleteResposta(int id)
        {
            SqlConnection con = new SqlConnection(connectionString);

            try

            {
                con.Open();

                SqlCommand cmd = new SqlCommand("PR_DeleteResposta", con);

                cmd.CommandType = CommandType.StoredProcedure;

                cmd.Parameters.AddWithValue("@id", id);

                return cmd.ExecuteNonQuery() != 0 ? true : false;
                
            }

            catch (Exception ex)

            {

                throw ex;  // retorna mensagem de erro

            }

            finally

            {

                con.Close();

            }
        }

    }
}

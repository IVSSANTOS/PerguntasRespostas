using PerguntasRespostas.Entidades;
using System;
using System.Collections.Generic;
using System.Text;
using System.Linq;
using System.Threading.Tasks;

using System.Data.SqlClient;

using System.Data;

namespace PerguntasRespostas.Dados
{
    public class PerguntaDAL
    {
        private string connectionString = new DBConfiguration().GetconfigurationStringSQL();
        
        public IEnumerable<Pergunta> GetPergunta()
        {
            List<Pergunta> ListaObj = new List<Pergunta>();

            SqlConnection con = new SqlConnection(connectionString);

            try

            {
                con.Open();

                SqlCommand cmd = new SqlCommand("PR_GetPergunta", con);

                cmd.CommandType = CommandType.StoredProcedure;

                SqlDataReader dr = cmd.ExecuteReader();

                while (dr.Read())

                {

                    Pergunta obj = new Pergunta();
                    
                    obj.Id = dr["Id"].ToString().Equals(string.Empty) ? 0 : Convert.ToInt32(dr["Id"].ToString());

                    obj.IdAutor = dr["IdAutor"].ToString().Equals(string.Empty) ? 0 : Convert.ToInt32(dr["IdAutor"].ToString());

                    obj.IdCategoria = dr["IdCategoria"].ToString().Equals(string.Empty) ? 0 : Convert.ToInt32(dr["IdCategoria"].ToString());

                    obj.Descricao = dr["Descricao"].ToString();
                        
                    obj.Ativo = dr["Ativo"].ToString().Equals(string.Empty) ? false : Convert.ToBoolean(dr["Ativo"].ToString());

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

        public Pergunta GetPergunta(int id)
        {
            SqlConnection con = new SqlConnection(connectionString);

            try

            {
                con.Open();

                SqlCommand cmd = new SqlCommand("PR_GetPergunta", con);

                cmd.CommandType = CommandType.StoredProcedure;

                cmd.Parameters.AddWithValue("@Id", id);

                SqlDataReader dr = cmd.ExecuteReader();

                Pergunta obj = new Pergunta();

                while (dr.Read())

                {                                      

                    obj.Id = dr["Id"].ToString().Equals(string.Empty) ? 0 : Convert.ToInt32(dr["Id"].ToString());

                    obj.Descricao = dr["Descricao"].ToString();

                    obj.IdAutor = dr["IdAutor"].ToString().Equals(string.Empty) ? 0 : Convert.ToInt32(dr["IdAutor"].ToString());

                    obj.IdCategoria = dr["IdCategoria"].ToString().Equals(string.Empty) ? 0 : Convert.ToInt32(dr["IdCategoria"].ToString());
                    
                    obj.Ativo = dr["Ativo"].ToString().Equals(string.Empty) ? false : Convert.ToBoolean(dr["Ativo"].ToString());

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

        public bool PutPergunta(int id, Pergunta Pergunta)
        {
            SqlConnection con = new SqlConnection(connectionString);

            try

            {

                con.Open();

                SqlCommand cmd = new SqlCommand("PR_PutPergunta", con);

                cmd.CommandType = CommandType.StoredProcedure;
                               
                cmd.Parameters.AddWithValue("@id", id);

                cmd.Parameters.AddWithValue("@Descricao", Pergunta.Descricao);

                cmd.Parameters.AddWithValue("@IdAutor", Pergunta.IdAutor);

                cmd.Parameters.AddWithValue("@IdCategoria", Pergunta.IdCategoria);

                cmd.Parameters.AddWithValue("@Ativo", Pergunta.Ativo);

                cmd.Parameters.AddWithValue("@DataCriacao", Pergunta.DataCriacao);

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

        public bool PostPergunta(Pergunta Pergunta)
        {
            SqlConnection con = new SqlConnection(connectionString);

            try

            {
                con.Open();

                SqlCommand cmd = new SqlCommand("PR_PostPergunta", con);

                cmd.CommandType = CommandType.StoredProcedure;
                               
                cmd.Parameters.AddWithValue("@Descricao", Pergunta.Descricao);
                                
                cmd.Parameters.AddWithValue("@IdAutor", Pergunta.IdAutor);

                cmd.Parameters.AddWithValue("@IdCategoria", Pergunta.IdCategoria);

                cmd.Parameters.AddWithValue("@Ativo", Pergunta.Ativo);

                cmd.Parameters.AddWithValue("@DataCriacao", Pergunta.DataCriacao);

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

        public bool DeletePergunta(int id)
        {
            SqlConnection con = new SqlConnection(connectionString);

            try

            {
                con.Open();

                SqlCommand cmd = new SqlCommand("PR_DeletePergunta", con);

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

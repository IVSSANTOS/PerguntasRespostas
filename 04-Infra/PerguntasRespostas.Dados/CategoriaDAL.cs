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
    public class CategoriaDAL
    {
        private string connectionString = new DBConfiguration().GetconfigurationStringSQL();

        public IEnumerable<Categoria> GetCategoria()
        {
            List<Categoria> ListaObj = new List<Categoria>();

            SqlConnection con = new SqlConnection(connectionString);

            try

            {
                con.Open();

                SqlCommand cmd = new SqlCommand("PR_GetCategoria", con);

                cmd.CommandType = CommandType.StoredProcedure;

                SqlDataReader dr = cmd.ExecuteReader();

                while (dr.Read())

                {

                    Categoria obj = new Categoria();

                    obj.Id = dr["Id"].ToString().Equals(string.Empty) ? 0 : Convert.ToInt32(dr["Id"].ToString());

                    obj.Descricao = dr["Descricao"].ToString();

                    obj.Ativo = dr["Ativo"].ToString().Equals(string.Empty) ? false : Convert.ToBoolean(dr["Ativo"].ToString());

                    obj.Titulo = dr["Titulo"].ToString();

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

        public Categoria GetCategoria(int id)
        {
            SqlConnection con = new SqlConnection(connectionString);

            try

            {
                con.Open();

                SqlCommand cmd = new SqlCommand("PR_GetCategoria", con);

                cmd.CommandType = CommandType.StoredProcedure;

                cmd.Parameters.AddWithValue("@Id", id);

                SqlDataReader dr = cmd.ExecuteReader();

                Categoria obj = new Categoria();

                while (dr.Read())

                {

                    
                    obj.Id = dr["Id"].ToString().Equals(string.Empty) ? 0 : Convert.ToInt32(dr["Id"].ToString());

                    obj.Descricao = dr["Descricao"].ToString();

                    obj.Titulo = dr["Titulo"].ToString();

                    obj.Ativo = dr["Ativo"].ToString().Equals(string.Empty) ? false : Convert.ToBoolean(dr["Ativo"].ToString());


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

        public bool PutCategoria(int id, Categoria categoria)
        {
            SqlConnection con = new SqlConnection(connectionString);

            try

            {

                con.Open();

                SqlCommand cmd = new SqlCommand("PR_PutCategoria", con);

                cmd.CommandType = CommandType.StoredProcedure;

                cmd.Parameters.AddWithValue("@id", id);

                cmd.Parameters.AddWithValue("@Descricao", categoria.Descricao);

                cmd.Parameters.AddWithValue("@Titulo", categoria.Titulo);

                cmd.Parameters.AddWithValue("@Ativo", categoria.Ativo);

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

        public bool PostCategoria(Categoria categoria)
        {
            SqlConnection con = new SqlConnection(connectionString);

            try

            {
                con.Open();

                SqlCommand cmd = new SqlCommand("PR_PostCategoria", con);

                cmd.CommandType = CommandType.StoredProcedure;

                cmd.Parameters.AddWithValue("@Descricao", categoria.Descricao);

                cmd.Parameters.AddWithValue("@Titulo", categoria.Titulo);

                cmd.Parameters.AddWithValue("@Ativo", categoria.Ativo);

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

        public bool DeleteCategoria(int id)
        {
            SqlConnection con = new SqlConnection(connectionString);

            try

            {
                con.Open();

                SqlCommand cmd = new SqlCommand("PR_DeleteCategoria", con);

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

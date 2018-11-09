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
    public class AutorDAL
    {
        private string connectionString = new DBConfiguration().GetconfigurationStringSQL();

        public IEnumerable<Autor> GetAutor()
        {
            List<Autor> ListaObj = new List<Autor>();

            SqlConnection con = new SqlConnection(connectionString);

            try

            {
                con.Open();

                SqlCommand cmd = new SqlCommand("PR_GetAutor", con);

                cmd.CommandType = CommandType.StoredProcedure;

                SqlDataReader dr = cmd.ExecuteReader();

                while (dr.Read())

                {

                    Autor obj = new Autor();

                    obj.Id = dr["Id"].ToString().Equals(string.Empty) ? 0 : Convert.ToInt32(dr["Id"].ToString());

                    obj.Nome = dr["Nome"].ToString();

                    obj.Email = dr["Email"].ToString();

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

        public Autor GetAutor(int id)
        {
            SqlConnection con = new SqlConnection(connectionString);

            try

            {
                con.Open();

                SqlCommand cmd = new SqlCommand("PR_GetAutor", con);

                cmd.CommandType = CommandType.StoredProcedure;

                cmd.Parameters.AddWithValue("@Id", id);

                SqlDataReader dr = cmd.ExecuteReader();

                Autor obj = new Autor();

                while (dr.Read())

                {

                  

                    obj.Id = dr["Id"].ToString().Equals(string.Empty) ? 0 : Convert.ToInt32(dr["Id"].ToString());

                    obj.Nome = dr["Nome"].ToString();

                    obj.Email = dr["Email"].ToString();

                    
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

        public bool PutAutor(int id, Autor Autor)
        {
            SqlConnection con = new SqlConnection(connectionString);

            try

            {

                con.Open();

                SqlCommand cmd = new SqlCommand("PR_PutAutor", con);

                cmd.CommandType = CommandType.StoredProcedure;

                cmd.Parameters.AddWithValue("@id", id);

                cmd.Parameters.AddWithValue("@Nome", Autor.Nome);

                cmd.Parameters.AddWithValue("@Email", Autor.Email);

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

        public bool PostAutor(Autor Autor)
        {
            SqlConnection con = new SqlConnection(connectionString);

            try

            {
                con.Open();

                SqlCommand cmd = new SqlCommand("PR_PostAutor", con);

                cmd.CommandType = CommandType.StoredProcedure;

                cmd.Parameters.AddWithValue("@Nome", Autor.Nome);

                cmd.Parameters.AddWithValue("@Email", Autor.Email);

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

        public bool DeleteAutor(int id)
        {
            SqlConnection con = new SqlConnection(connectionString);

            try

            {
                con.Open();

                SqlCommand cmd = new SqlCommand("PR_DeleteAutor", con);

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

using PerguntasRespostas.Dados;
using PerguntasRespostas.Entidades;
using System;
using System.Collections.Generic;
using System.Text;

namespace PerguntasRespostas.Negocio
{
    public class CategoriaBLL
    {
        public IEnumerable<Categoria> GetCategoria()
        {

            try

            {

                return new CategoriaDAL().GetCategoria();

            }

            catch (Exception ex)

            {

                throw ex;

            }


        }

        public Categoria GetCategoria(int id)
        {


            try

            {
                return new CategoriaDAL().GetCategoria(id);

            }

            catch (Exception ex)

            {

                throw ex;

            }

        }

        public bool PutCategoria(int id, Categoria categoria)
        {


            try

            {

                return new CategoriaDAL().PutCategoria(id, categoria);


            }

            catch (Exception ex)

            {

                throw ex;  // retorna mensagem de erro

            }


        }

        public bool PostCategoria(Categoria categoria)
        {


            try

            {
                return new CategoriaDAL().PostCategoria(categoria);


            }

            catch (Exception ex)

            {

                throw ex;  // retorna mensagem de erro

            }


        }

        public bool DeleteCategoria(int id)
        {
            try

            {
                return new CategoriaDAL().DeleteCategoria(id);

            }

            catch (Exception ex)

            {

                throw ex;  // retorna mensagem de erro

            }
        }

    }
}

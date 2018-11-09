using PerguntasRespostas.Dados;
using PerguntasRespostas.Entidades;
using System;
using System.Collections.Generic;
using System.Text;

namespace PerguntasRespostas.Negocio
{
    public class AutorBLL
    {
        public IEnumerable<Autor> GetAutor()
        {

            try

            {

                return new AutorDAL().GetAutor();

            }

            catch (Exception ex)

            {

                throw ex;

            }


        }

        public Autor GetAutor(int id)
        {


            try

            {
                return new AutorDAL().GetAutor(id);

            }

            catch (Exception ex)

            {

                throw ex;

            }

        }

        public bool PutAutor(int id, Autor Autor)
        {


            try

            {

                return new AutorDAL().PutAutor(id, Autor);


            }

            catch (Exception ex)

            {

                throw ex;  // retorna mensagem de erro

            }


        }

        public bool PostAutor(Autor Autor)
        {


            try

            {
                return new AutorDAL().PostAutor(Autor);


            }

            catch (Exception ex)

            {

                throw ex;  // retorna mensagem de erro

            }


        }

        public bool DeleteAutor(int id)
        {
            try

            {
                return new AutorDAL().DeleteAutor(id);

            }

            catch (Exception ex)

            {

                throw ex;  // retorna mensagem de erro

            }
        }

    }
}

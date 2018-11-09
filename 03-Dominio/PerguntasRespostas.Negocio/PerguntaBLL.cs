using PerguntasRespostas.Dados;
using PerguntasRespostas.Entidades;
using System;
using System.Collections.Generic;
using System.Text;

namespace PerguntasRespostas.Negocio
{
    public class PerguntaBLL
    {
        public IEnumerable<Pergunta> GetPergunta()
        {

            try

            {

                return new PerguntaDAL().GetPergunta();

            }

            catch (Exception ex)

            {

                throw ex;

            }


        }

        public Pergunta GetPergunta(int id)
        {


            try

            {
                return new PerguntaDAL().GetPergunta(id);

            }

            catch (Exception ex)

            {

                throw ex;

            }

        }

        public bool PutPergunta(int id, Pergunta Pergunta)
        {


            try

            {

                return new PerguntaDAL().PutPergunta(id, Pergunta);


            }

            catch (Exception ex)

            {

                throw ex;  // retorna mensagem de erro

            }


        }

        public bool PostPergunta(Pergunta Pergunta)
        {


            try

            {
                return new PerguntaDAL().PostPergunta(Pergunta);


            }

            catch (Exception ex)

            {

                throw ex;  // retorna mensagem de erro

            }


        }

        public bool DeletePergunta(int id)
        {
            try

            {
                return new PerguntaDAL().DeletePergunta(id);

            }

            catch (Exception ex)

            {

                throw ex;  // retorna mensagem de erro

            }
        }

    }
}

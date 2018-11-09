using PerguntasRespostas.Entidades;
using RespostasRespostas.Dados;
using System;
using System.Collections.Generic;
using System.Text;

namespace RespostasRespostas.Negocio
{
    public class RespostaBLL
    {
        public IEnumerable<Resposta> GetResposta()
        {

            try

            {

                return new RespostaDAL().GetResposta();

            }

            catch (Exception ex)

            {

                throw ex;

            }


        }

        public Resposta GetResposta(int id)
        {


            try

            {
                return new RespostaDAL().GetResposta(id);

            }

            catch (Exception ex)

            {

                throw ex;

            }

        }

        public bool PutResposta(int id, Resposta Resposta)
        {


            try

            {

                return new RespostaDAL().PutResposta(id, Resposta);


            }

            catch (Exception ex)

            {

                throw ex;  // retorna mensagem de erro

            }


        }

        public bool PostResposta(Resposta Resposta)
        {


            try

            {
                return new RespostaDAL().PostResposta(Resposta);


            }

            catch (Exception ex)

            {

                throw ex;  // retorna mensagem de erro

            }


        }

        public bool DeleteResposta(int id)
        {
            try

            {
                return new RespostaDAL().DeleteResposta(id);

            }

            catch (Exception ex)

            {

                throw ex;  // retorna mensagem de erro

            }
        }

    }
}

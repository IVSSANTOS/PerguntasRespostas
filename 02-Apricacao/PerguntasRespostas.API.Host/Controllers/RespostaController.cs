using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using PerguntasRespostas.Entidades;
using RespostasRespostas.Negocio;

namespace RespostasRespostas.API.Host.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class RespostaController : ControllerBase
    {
        // GET api/Resposta
        [HttpGet]
        public ActionResult<IEnumerable<Resposta>> Get()
        {

            var lista = new RespostaBLL().GetResposta();

            if (lista.Count() > 0)
            {
                return Ok(lista);
            }

            return BadRequest("A pesquisa não retornou resultado");
        }

        // GET api/Resposta/5
        [HttpGet("{id}")]
        public ActionResult<Resposta> Get(int id)
        {
            var obj = new RespostaBLL().GetResposta(id);

            if (obj != null)
            {
                return Ok(obj);
            }

            return BadRequest("A pesquisa não retornou resultado");
        }

        // POST api/Resposta
        [HttpPost]
        public ActionResult Post([FromBody] Resposta value)
        {
            var obj = new RespostaBLL().PostResposta(value);

            if (obj)
            {
                return Ok();
            }

            return BadRequest("Não foi possível inserir o registro");
        }

        // PUT api/Resposta/5
        [HttpPut("{id}")]
        public ActionResult Put(int id, [FromBody] Resposta value)
        {
            var obj = new RespostaBLL().PutResposta(id, value);

            if (obj)
            {
                return Ok();
            }

            return BadRequest("Não foi possível alterar o registro");
        }

        // DELETE api/Resposta/5
        [HttpDelete("{id}")]
        public ActionResult Delete(int id)
        {
            var obj = new RespostaBLL().DeleteResposta(id);

            if (obj)
            {
                return Ok();
            }

            return BadRequest("Não foi possível excluir o registro");
        }
    }
}

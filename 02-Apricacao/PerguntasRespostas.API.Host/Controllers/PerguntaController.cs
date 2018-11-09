using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using PerguntasRespostas.Entidades;
using PerguntasRespostas.Negocio;

namespace PerguntasRespostas.API.Host.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class PerguntaController : ControllerBase
    {
        // GET api/Pergunta
        [HttpGet]
        public ActionResult<IEnumerable<Pergunta>> Get()
        {

            var lista = new PerguntaBLL().GetPergunta();

            if (lista.Count() > 0)
            {
                return Ok(lista);
            }

            return BadRequest("A pesquisa não retornou resultado");
        }

        // GET api/Pergunta/5
        [HttpGet("{id}")]
        public ActionResult<Pergunta> Get(int id)
        {
            var obj = new PerguntaBLL().GetPergunta(id);

            if (obj != null)
            {
                return Ok(obj);
            }

            return BadRequest("A pesquisa não retornou resultado");
        }

        // POST api/Pergunta
        [HttpPost]
        public ActionResult Post([FromBody] Pergunta value)
        {
            var obj = new PerguntaBLL().PostPergunta(value);

            if (obj)
            {
                return Ok();
            }

            return BadRequest("Não foi possível inserir o registro");
        }

        // PUT api/Pergunta/5
        [HttpPut("{id}")]
        public ActionResult Put(int id, [FromBody] Pergunta value)
        {
            var obj = new PerguntaBLL().PutPergunta(id, value);

            if (obj)
            {
                return Ok();
            }

            return BadRequest("Não foi possível alterar o registro");
        }

        // DELETE api/Pergunta/5
        [HttpDelete("{id}")]
        public ActionResult Delete(int id)
        {
            var obj = new PerguntaBLL().DeletePergunta(id);

            if (obj)
            {
                return Ok();
            }

            return BadRequest("Não foi possível excluir o registro");
        }
    }
}

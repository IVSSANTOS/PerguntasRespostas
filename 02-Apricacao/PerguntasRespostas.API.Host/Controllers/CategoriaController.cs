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
    public class CategoriaController : ControllerBase
    {
        // GET api/Categoria
        [HttpGet]
        public ActionResult<IEnumerable<Categoria>> Get()
        {

            var lista = new CategoriaBLL().GetCategoria();

            if (lista.Count() > 0)
            {
                return Ok(lista);
            }

            return BadRequest("A pesquisa não retornou resultado");
        }

        // GET api/Categoria/5
        [HttpGet("{id}")]
        public ActionResult<Categoria> Get(int id)
        {
            var obj = new CategoriaBLL().GetCategoria(id);

            if (obj != null)
            {
                return Ok(obj);
            }

            return BadRequest("A pesquisa não retornou resultado");
        }

        // POST api/Categoria
        [HttpPost]
        public ActionResult Post([FromBody] Categoria value)
        {
            var obj = new CategoriaBLL().PostCategoria(value);

            if (obj)
            {
                return Ok();
            }

            return BadRequest("Não foi possível inserir o registro");
        }

        // PUT api/Categoria/5
        [HttpPut("{id}")]
        public ActionResult Put(int id, [FromBody] Categoria value)
        {
            var obj = new CategoriaBLL().PutCategoria(id, value);

            if (obj)
            {
                return Ok();
            }

            return BadRequest("Não foi possível alterar o registro");
        }

        // DELETE api/Categoria/5
        [HttpDelete("{id}")]
        public ActionResult Delete(int id)
        {
            var obj = new CategoriaBLL().DeleteCategoria(id);

            if (obj)
            {
                return Ok();
            }

            return BadRequest("Não foi possível excluir o registro");
        }
    }
}

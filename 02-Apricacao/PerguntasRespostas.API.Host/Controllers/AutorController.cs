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
    public class AutorController : ControllerBase
    {
        // GET api/Autor
        [HttpGet]
        public ActionResult<IEnumerable<Autor>> Get()
        {

            var lista = new AutorBLL().GetAutor();

            if (lista.Count() > 0)
            {
                return Ok(lista);
            }

            return BadRequest("A pesquisa não retornou resultado");
        }

        // GET api/Autor/5
        [HttpGet("{id}")]
        public ActionResult<Autor> Get(int id)
        {
            var obj = new AutorBLL().GetAutor(id);

            if (obj != null)
            {
                return Ok(obj);
            }

            return BadRequest("A pesquisa não retornou resultado");
        }

        // POST api/Autor
        [HttpPost]
        public ActionResult Post([FromBody] Autor value)
        {
            var obj = new AutorBLL().PostAutor(value);

            if (obj)
            {
                return Ok();
            }

            return BadRequest("Não foi possível inserir o registro");
        }

        // PUT api/Autor/5
        [HttpPut("{id}")]
        public ActionResult Put(int id, [FromBody] Autor value)
        {
            var obj = new AutorBLL().PutAutor(id, value);

            if (obj)
            {
                return Ok();
            }

            return BadRequest("Não foi possível alterar o registro");
        }

        // DELETE api/Autor/5
        [HttpDelete("{id}")]
        public ActionResult Delete(int id)
        {
            var obj = new AutorBLL().DeleteAutor(id);

            if (obj)
            {
                return Ok();
            }

            return BadRequest("Não foi possível excluir o registro");
        }
    }
}

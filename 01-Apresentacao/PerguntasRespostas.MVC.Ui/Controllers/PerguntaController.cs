using System;
using System.Collections.Generic;
using System.Linq;
using System.Net.Http;
using System.Net.Http.Headers;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.Rendering;
using Newtonsoft.Json;
using PerguntasRespostas.MVC.Ui.Models;

namespace PerguntasRespostas.MVC.Ui.Controllers
{
    public class PerguntaController : Controller
    {
        HttpClient client = new HttpClient();

        private readonly string _CONTROLLER = "Pergunta";
        private readonly string _CONTROLLER_CATEGORIA = "Categoria";
        private readonly string _CONTROLLER_AUTOR = "Autor";
        private readonly string _CONTROLLER_RESPOSTA = "Resposta";

        List<PerguntaModel> lista;

        public PerguntaController()
        {

            client.BaseAddress = new Uri("https://localhost:5001/api/" + _CONTROLLER);
            client.DefaultRequestHeaders.Accept.Clear();
            client.DefaultRequestHeaders.Accept.Add(new MediaTypeWithQualityHeaderValue("application/json"));
        }

        // GET: Pergunta
        public ActionResult Index()
        {

           

            lista = new List<PerguntaModel>();

            string requestUrl = "/api/" + _CONTROLLER;

            HttpResponseMessage response = client.GetAsync(requestUrl).Result;

            if (response.IsSuccessStatusCode)
            {
                var data = response.Content.ReadAsStringAsync().Result;

                lista = JsonConvert.DeserializeObject<List<PerguntaModel>>(data);
            }

            return View(lista);
        }

        // GET: Pergunta/ListRespostas/5
        public ActionResult ListRespostas(int id)
        {
            List<RespostaModel> lista = new List<RespostaModel>();

            string requestUrl = "/api/" + _CONTROLLER_RESPOSTA + "/" + id;

            HttpResponseMessage response = client.GetAsync(requestUrl, HttpCompletionOption.ResponseHeadersRead).Result;

            if (response.IsSuccessStatusCode)
            {
                var data = response.Content.ReadAsStringAsync().Result;

                lista = JsonConvert.DeserializeObject<List<RespostaModel>>(data);

                if (lista != null && lista.Count >0)
                    return View(lista);
                else
                    return NotFound();
            }
            else
                return View();
        }

        // GET: Pergunta/Create
        public ActionResult Create()
        {
            PerguntaModel pergunta = new PerguntaModel()
            {
                IdAutor = ObterAutorLogado().Id


            };
            

            var listaCategoria = this.ListarCategorias().Where(item=>item.Ativo == true).Select(c => new SelectListItem()
            { Text = c.Titulo, Value = c.Id.ToString() }).ToList();

            ViewBag.Categorias = listaCategoria;
           
            return View(pergunta);
        }

        // POST: Pergunta/Create
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Create(PerguntaModel model)
        {
            try
            {
                
                model.DataCriacao = DateTime.Now;


                string requestUrl = "/api/" + _CONTROLLER + "/";

                HttpResponseMessage response = client.PostAsJsonAsync<PerguntaModel>(requestUrl, model).Result;


                if (response.IsSuccessStatusCode)
                {
                    return RedirectToAction("Index");
                }
                else
                {
                    ViewBag.Error = "Erro na criação do registro.";
                    return View();
                }
            }
            catch
            {
                return View();
            }
        }

        // GET: Pergunta/Edit/5
        public ActionResult Edit(int id)
        {
            string requestUrl = "/api/" + _CONTROLLER + "/" + id;

            HttpResponseMessage response = client.GetAsync(requestUrl, HttpCompletionOption.ResponseHeadersRead).Result;

            if (response.IsSuccessStatusCode)
            {
                var data = response.Content.ReadAsStringAsync().Result;

                PerguntaModel model = JsonConvert.DeserializeObject<PerguntaModel>(data);
                
                RespostaModel resposta = new RespostaModel();

                ViewBag.Pergunta = model.Descricao;
                resposta.IdAutor = model.IdAutor;
                resposta.IdPergunta = model.Id;


                if (model != null)
                    return View(resposta);
                else
                    return NotFound();
            }
            else
                return View();
        }

        // POST: Pergunta/Edit/5
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Edit(int id, RespostaModel model)
        {
            try
            {
                model.DataCriacao = DateTime.Now;
                string requestUrl = "/api/" + _CONTROLLER_RESPOSTA + "/";

                HttpResponseMessage response = client.PostAsJsonAsync<RespostaModel>(requestUrl, model).Result;

                if (response.IsSuccessStatusCode)
                {
                    return RedirectToAction("Index");

                }

                else
                {
                    ViewBag.Error = "Erro na edição do registro.";
                    return View();
                }
            }
            catch
            {
                return View();
            }
        }

        // GET: Pergunta/Delete/5
        public ActionResult Delete(int id)
        {
            string requestUrl = "/api/" + _CONTROLLER + "/" + id;

            HttpResponseMessage response = client.GetAsync(requestUrl, HttpCompletionOption.ResponseHeadersRead).Result;

            if (response.IsSuccessStatusCode)
            {
                var data = response.Content.ReadAsStringAsync().Result;

                PerguntaModel model = JsonConvert.DeserializeObject<PerguntaModel>(data);

                if (model != null)
                    return View(model);
                else
                    return NotFound();

            }
            else
                return NotFound();
        }

        // POST: Pergunta/Delete/5
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Delete(int id, PerguntaModel model)
        {
            try
            {
                string requestUrl = "/api/" + _CONTROLLER + "/" + id;

                HttpResponseMessage response = client.DeleteAsync(requestUrl).Result;

                if (response.IsSuccessStatusCode)
                {
                    return RedirectToAction("Index");

                }
                else
                {
                    ViewBag.Error = "Erro na exclusão do registro.";
                    return View();
                }

            }
            catch
            {
                return View();
            }
        }
        
        public List<CategoriaModel> ListarCategorias()
        {
            List<CategoriaModel> lista = new List<CategoriaModel>();

            string requestUrl = "/api/" + _CONTROLLER_CATEGORIA;

            HttpResponseMessage response = client.GetAsync(requestUrl).Result;

            if (response.IsSuccessStatusCode)
            {
                var data = response.Content.ReadAsStringAsync().Result;

                lista = JsonConvert.DeserializeObject<List<CategoriaModel>>(data);
            }

            return lista;
        }
        
        public AutorModel ObterAutorLogado()
        {
            AutorModel autor = new AutorModel();
           
            string requestUrl = "/api/" + _CONTROLLER_AUTOR;

            HttpResponseMessage response = client.GetAsync(requestUrl).Result;

            if (response.IsSuccessStatusCode)
            {
                var data = response.Content.ReadAsStringAsync().Result;

                autor = JsonConvert.DeserializeObject<List<AutorModel>>(data).Where(x=>x.Nome.Equals(Environment.UserName.ToString())).FirstOrDefault();
            }

            return autor;
        }




    }
}
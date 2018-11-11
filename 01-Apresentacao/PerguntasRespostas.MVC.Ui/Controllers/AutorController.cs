using System;
using System.Collections.Generic;
using System.Linq;
using System.Net.Http;
using System.Net.Http.Headers;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using Newtonsoft.Json;
using PerguntasRespostas.MVC.Ui.Models;

namespace PerguntasRespostas.MVC.Ui.Controllers
{
    public class AutorController : Controller
    {
        HttpClient client = new HttpClient();

        private readonly string _CONTROLLER = "Autor";

        List<AutorModel> lista;

        public AutorController()
        {

            client.BaseAddress = new Uri("https://localhost:5001/api/" + _CONTROLLER);
            client.DefaultRequestHeaders.Accept.Clear();
            client.DefaultRequestHeaders.Accept.Add(new MediaTypeWithQualityHeaderValue("application/json"));
        }

        // GET: Autor
        public ActionResult Index()
        {
            lista = new List<AutorModel>();

            string requestUrl = "/api/" + _CONTROLLER;

            HttpResponseMessage response = client.GetAsync(requestUrl).Result;

            if (response.IsSuccessStatusCode)
            {
                var data = response.Content.ReadAsStringAsync().Result;

                lista = JsonConvert.DeserializeObject<List<AutorModel>>(data);
            }

            return View(lista);
        }

        // GET: Autor/Details/5
        public ActionResult Details(int id)
        {

            string requestUrl = "/api/" + _CONTROLLER + "/" + id;

            HttpResponseMessage response = client.GetAsync(requestUrl, HttpCompletionOption.ResponseHeadersRead).Result;

            if (response.IsSuccessStatusCode)
            {
                var data = response.Content.ReadAsStringAsync().Result;

                AutorModel model = JsonConvert.DeserializeObject<AutorModel>(data);

                if (model != null)
                    return View(model);
                else
                    return NotFound();
            }
            else
                return View();
        }

        // GET: Autor/Create
        public ActionResult Create()
        {

            AutorModel autor = new AutorModel();
            autor.Nome = Environment.UserName.ToString();
            return View(autor);
        }

        // POST: Autor/Create
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Create(AutorModel model)
        {
            try
            {
              
                string requestUrl = "/api/" + _CONTROLLER + "/";

                HttpResponseMessage response = client.PostAsJsonAsync<AutorModel>(requestUrl, model).Result;


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

        // GET: Autor/Edit/5
        public ActionResult Edit(int id)
        {
            string requestUrl = "/api/" + _CONTROLLER + "/" + id;

            HttpResponseMessage response = client.GetAsync(requestUrl, HttpCompletionOption.ResponseHeadersRead).Result;

            if (response.IsSuccessStatusCode)
            {
                var data = response.Content.ReadAsStringAsync().Result;

                AutorModel model = JsonConvert.DeserializeObject<AutorModel>(data);

                if (model != null)
                    return View(model);
                else
                    return NotFound();
            }
            else
                return View();
        }

        // POST: Autor/Edit/5
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Edit(int id, AutorModel model)
        {
            try
            {
                string requestUrl = "/api/" + _CONTROLLER + "/" + id;

                HttpResponseMessage response = client.PutAsJsonAsync<AutorModel>(requestUrl, model).Result;

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

        // GET: Autor/Delete/5
        public ActionResult Delete(int id)
        {
            string requestUrl = "/api/" + _CONTROLLER + "/" + id;

            HttpResponseMessage response = client.GetAsync(requestUrl, HttpCompletionOption.ResponseHeadersRead).Result;

            if (response.IsSuccessStatusCode)
            {
                var data = response.Content.ReadAsStringAsync().Result;

                AutorModel model = JsonConvert.DeserializeObject<AutorModel>(data);

                if (model != null)
                    return View(model);
                else
                    return NotFound();

            }
            else
                return NotFound();
        }

        // POST: Autor/Delete/5
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Delete(int id, AutorModel model)
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
    }
}
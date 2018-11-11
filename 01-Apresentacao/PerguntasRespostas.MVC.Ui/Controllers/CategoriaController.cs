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
    public class CategoriaController : Controller
    {
        HttpClient client = new HttpClient();

        private readonly string _CONTROLLER = "Categoria";

        List<CategoriaModel> lista;

        public CategoriaController()
        {

            client.BaseAddress = new Uri("https://localhost:5001/api/" + _CONTROLLER);
            client.DefaultRequestHeaders.Accept.Clear();
            client.DefaultRequestHeaders.Accept.Add(new MediaTypeWithQualityHeaderValue("application/json"));
        }

        // GET: Categoria
        public ActionResult Index()
        {
            lista = new List<CategoriaModel>();

            string requestUrl = "/api/" + _CONTROLLER;

            HttpResponseMessage response = client.GetAsync(requestUrl).Result;

            if (response.IsSuccessStatusCode)
            {
                var data = response.Content.ReadAsStringAsync().Result;

                lista = JsonConvert.DeserializeObject<List<CategoriaModel>>(data);
            }

            return View(lista);
        }

        // GET: Categoria/Details/5
        public ActionResult Details(int id)
        {

            string requestUrl = "/api/" + _CONTROLLER + "/" + id;

            HttpResponseMessage response = client.GetAsync(requestUrl, HttpCompletionOption.ResponseHeadersRead).Result;

            if (response.IsSuccessStatusCode)
            {
                var data = response.Content.ReadAsStringAsync().Result;

                CategoriaModel model = JsonConvert.DeserializeObject<CategoriaModel>(data);

                if (model != null)
                    return View(model);
                else
                    return NotFound();
            }
            else
                return View();
        }

        // GET: Categoria/Create
        public ActionResult Create()
        {
            return View();
        }

        // POST: Categoria/Create
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Create(CategoriaModel model)
        {
            try
            {

                string requestUrl = "/api/" + _CONTROLLER + "/";

                HttpResponseMessage response = client.PostAsJsonAsync<CategoriaModel>(requestUrl, model).Result;


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

        // GET: Categoria/Edit/5
        public ActionResult Edit(int id)
        {
            string requestUrl = "/api/" + _CONTROLLER + "/" + id;

            HttpResponseMessage response = client.GetAsync(requestUrl, HttpCompletionOption.ResponseHeadersRead).Result;

            if (response.IsSuccessStatusCode)
            {
                var data = response.Content.ReadAsStringAsync().Result;

                CategoriaModel model = JsonConvert.DeserializeObject<CategoriaModel>(data);

                if (model != null)
                    return View(model);
                else
                    return NotFound();
            }
            else
                return View();
        }

        // POST: Categoria/Edit/5
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Edit(int id, CategoriaModel model)
        {
            try
            {
                string requestUrl = "/api/" + _CONTROLLER + "/" + id;

                HttpResponseMessage response = client.PutAsJsonAsync<CategoriaModel>(requestUrl, model).Result;

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

        // GET: Categoria/Delete/5
        public ActionResult Delete(int id)
        {
            string requestUrl = "/api/" + _CONTROLLER + "/" + id;

            HttpResponseMessage response = client.GetAsync(requestUrl, HttpCompletionOption.ResponseHeadersRead).Result;

            if (response.IsSuccessStatusCode)
            {
                var data = response.Content.ReadAsStringAsync().Result;

                CategoriaModel model = JsonConvert.DeserializeObject<CategoriaModel>(data);

                if (model != null)
                    return View(model);
                else
                    return NotFound();

            }
            else
                return NotFound();
        }

        // POST: Categoria/Delete/5
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Delete(int id, CategoriaModel model)
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
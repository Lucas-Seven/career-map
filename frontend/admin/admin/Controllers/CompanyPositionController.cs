﻿using admin.Services;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;

namespace admin.Controllers
{
    public class CompanyPositionController : Controller
    {
        //private CompanyPositionService _service;

        //public CompanyPositionController()
        //{
        //    _service = new CompanyPositionService();
        //}

        // GET: CompanyPositionController
        public ActionResult Index()
        {
            //return View(_service);

            IEnumerable<CompanyPositionService> contatos = null;

            using (var client = new HttpClient())
            {
                client.BaseAddress = new Uri("https://localhost:7149/api/careerMaps/1/companyPositions");

                //HTTP GET
                var responseTask = client.GetAsync("contatos");
                responseTask.Wait();
                var result = responseTask.Result;

                if (result.IsSuccessStatusCode)
                {
                    var readTask = result.Content.ReadAsAsync<IList<CompanyPositionService>>();
                    readTask.Wait();
                    contatos = readTask.Result;
                }
                else
                {
                    contatos = Enumerable.Empty<CompanyPositionService>();
                    ModelState.AddModelError(string.Empty, "Erro no servidor. Contate o Administrador.");
                }
                return View(contatos);
            }
        }    

        // GET: CompanyPositionController/Details/5
        public ActionResult Informacao(int id)
        {
            return View();
        }

        // GET: CompanyPositionController/Create
        public ActionResult Create()
        {
            return View();
        }

        // POST: CompanyPositionController/Create
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Create(IFormCollection collection)
        {
            try
            {
                return RedirectToAction(nameof(Index));
            }
            catch
            {
                return View();
            }
        }

        // GET: CompanyPositionController/Edit/5
        public ActionResult Edit(int id)
        {
            return View();
        }

        // POST: CompanyPositionController/Edit/5
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Edit(int id, IFormCollection collection)
        {
            try
            {
                return RedirectToAction(nameof(Index));
            }
            catch
            {
                return View();
            }
        }

        // GET: CompanyPositionController/Delete/5
        public ActionResult Delete(int id)
        {
            return View();
        }

        // POST: CompanyPositionController/Delete/5
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Delete(int id, IFormCollection collection)
        {
            try
            {
                return RedirectToAction(nameof(Index));
            }
            catch
            {
                return View();
            }
        }
    }
}

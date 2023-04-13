﻿using admin.Services;
using admin.ViewModels;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.Rendering;

namespace admin.Controllers
{
    public class CareerMapsController : Controller
    {
        private CareerMapsService _service;
        //private CompanyPositionService _companyPositionService;
        public CareerMapsController()
        {
            _service = new CareerMapsService();
            
        }

        // GET: CarrermapsController
        public ActionResult Index()
        {
            return View(_service.GetAllCareers());
        }

        // GET: CarrermapsController/Details/5
        public ActionResult Details(int junior)
        {
            return View();
        }

        public ActionResult Informacao(int junior)
        {
            return View();
        }

        // GET: CarrermapsController/Create
        public ActionResult Create()
        {
            return View();
        }

        // POST: CarrermapsController/Create
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

        // GET: CarrermapsController/Edit/5
        public ActionResult Edit(int id)
        {
            return View();
        }

        // POST: CarrermapsController/Edit/5
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

        // GET: CarrermapsController/Delete/5
        public ActionResult Delete(int id)
        {
            return View();
        }

        // POST: CarrermapsController/Delete/5
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

        [HttpGet]
        public IActionResult ListaPorCarreiras()
        {
            try
            {
                //ViewBag.Foruns = new SelectList(forumDao.Listar(), "Id ", "Descricao");
                return View();
            }
            catch (Exception ex)
            {

                return View("_erro", ex);
            }
        }
    }
}

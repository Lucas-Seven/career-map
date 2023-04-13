using admin.Services;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;

namespace admin.Controllers
{
    public class CompanyPositionController : Controller
    {
        private CompanyPositionService _service;

        public CompanyPositionController()
        {
            _service = new CompanyPositionService();
        }

        // GET: CompanyPositionController
        public ActionResult Index()
        {
            return View(_service);
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

using admin.ViewModels;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;

namespace admin.Controllers
{
    public class CareerMapsController : Controller
    {
        // GET: CarrermapsController
        public ActionResult Index()
        {
            IEnumerable<CareerMapCompanyPositionsVM> lista = null;

            using (var client = new HttpClient())
            {
                client.BaseAddress = new Uri("https://localhost:7149/api/");

                //HTTP GET
                var responseTask = client.GetAsync("CareerMaps");
                responseTask.Wait();
                var result = responseTask.Result;

                if (result.IsSuccessStatusCode)
                {
                    var readTask = result.Content.ReadAsAsync<IList<CareerMapCompanyPositionsVM>>();
                    readTask.Wait();
                    lista = readTask.Result;
                }
                else
                {
                    lista = Enumerable.Empty<CareerMapCompanyPositionsVM>();
                    ModelState.AddModelError(string.Empty, "Erro no servidor. Contate o Administrador.");
                }
                return View(lista);
            }
        }

        // GET: CarrermapsController/Details/5
        public ActionResult Details(int id)
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
    }
}

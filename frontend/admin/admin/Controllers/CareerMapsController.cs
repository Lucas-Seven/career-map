using admin.Services;
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
        public ActionResult Details(int id)
        {
            //IEnumerable<CompanyPositionService> contatos = null;

            //using (var client = new HttpClient())
            //{
            //    client.BaseAddress = new Uri("https://localhost:7149/api/");

            //    //var r = "1";
            //    //HTTP GET
            //    var responseTask = client.GetAsync($"careerMaps/{id}/companyPositions");
            //    responseTask.Wait();
            //    var result = responseTask.Result;

            //    if (result.IsSuccessStatusCode)
            //    {
            //        var readTask = result.Content.ReadAsAsync<IList<CompanyPositionService>>();
            //        readTask.Wait();
            //        contatos = readTask.Result;
            //    }
            //    else
            //    {
            //        contatos = Enumerable.Empty<CompanyPositionService>();
            //        ModelState.AddModelError(string.Empty, "Erro no servidor. Contate o Administrador.");
            //    }
            //    return View(contatos);
            //}

            var contatos = new List<CompanyPositionVM>()
            {
                new CompanyPositionVM { CompanyPositionId = 1 , CompanyPositionName = "Analista Junior"  },
                new CompanyPositionVM { CompanyPositionId = 2 , CompanyPositionName = "Analista Pleno"  },
                new CompanyPositionVM { CompanyPositionId = 3 , CompanyPositionName = "Analista Sênior"  },
                new CompanyPositionVM { CompanyPositionId = 4 , CompanyPositionName = "Lider"  },
                new CompanyPositionVM { CompanyPositionId = 5 , CompanyPositionName = "Coordenador"  }

            };
            return View(contatos);
        }

        public ActionResult Informacao(int junior)
        {
            var contatos = new List<CompanyPositionRequirementsVM>()
            {
                new CompanyPositionRequirementsVM { company_position_id = 1 , company_position_name = "C#"  },
                new CompanyPositionRequirementsVM { company_position_id = 1 , company_position_name = "SQL"  },
                new CompanyPositionRequirementsVM { company_position_id = 1 , company_position_name = "AWS"  }
            };
            return View(contatos);           
           
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

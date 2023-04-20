using admin.ViewModels;
using Microsoft.AspNetCore.Mvc;

namespace admin.Controllers
{
    public class TesteController : Controller
    {
        public IActionResult Index()
        {
            IEnumerable<CareerMapCompanyPositionsVM> contatos = null;

            using (var client = new HttpClient())
            {
                client.BaseAddress = new Uri("https://localhost:7149/api/CareerMaps");

                //HTTP GET
                var responseTask = client.GetAsync("CareerMaps");
                responseTask.Wait();
                var result = responseTask.Result;

                if (result.IsSuccessStatusCode)
                {
                    var readTask = result.Content.ReadAsAsync<IList<CareerMapCompanyPositionsVM>>();
                    readTask.Wait();
                    contatos = readTask.Result;
                }
                else
                {
                    contatos = Enumerable.Empty<CareerMapCompanyPositionsVM>();
                    ModelState.AddModelError(string.Empty, "Erro no servidor. Contate o Administrador.");
                }
                return View(contatos);
            }
        }
    }
}

using admin.ViewModels;

namespace admin.Services
{
    public class CareerMapsService
    {
        public List<CareerMapVM> GetAllCareers()
        {
            //IEnumerable<CareerMapVM> lista = null;

            //using (var client = new HttpClient())
            //{
            //    client.BaseAddress = new Uri("https://localhost:7149/api/");

            //    //HTTP GET
            //    var responseTask = client.GetAsync("CareerMaps");
            //    responseTask.Wait();
            //    var result = responseTask.Result;

            //    if (result.IsSuccessStatusCode)
            //    {
            //        var readTask = result.Content.ReadAsAsync<IList<CareerMapVM>>();
            //        readTask.Wait();
            //        lista = readTask.Result;
            //    }
            //    else
            //    {
            //        lista = Enumerable.Empty<CareerMapVM>();
            //        ModelState.AddModelError(string.Empty, "Erro no servidor. Contate o Administrador.");
            //    }
            //    return View(lista);
            //}

            var careers = new List<CareerMapVM>();

            for(int i = 1; i <= 5; i++)
            {
                careers.Add(new CareerMapVM()
                {
                    CareerMapId = i,
                    CareerMapName = $"Carreira {i}"
                });
            };

            return careers;
        }
    }
}

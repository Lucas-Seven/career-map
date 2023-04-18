using admin.ViewModels;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore.Metadata.Internal;

namespace admin.Services
{
    public class CompanyPositionService : Controller
    {    
        public List<CompanyPositionVM> GetAllCompanyPositions( )
        {
            
            var companyPositions = new List<CompanyPositionVM>();

            var careers = new List<CareerMapVM>();

            for(int i = 1; i <= 5; i++)
            {
                careers.Add(new CareerMapVM()
                {
                    CareerMapId = i,
                    CareerMapName = $"Carreira {i}"
                });
            }

            companyPositions.Add(new CompanyPositionVM()
            {
                CompanyPositionId = 1,
                CompanyPositionName = "Posição 1"
            });

            return companyPositions;
        }     
        
        public ActionResult MeuTest( string meuValor = "valor1")
        {
            ViewBag.MeuValor = "Ola teste";
            return View();
        }
    }
}

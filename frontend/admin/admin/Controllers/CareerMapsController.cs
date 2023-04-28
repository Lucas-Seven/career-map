using admin.Api.Model.Response;
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


        public ActionResult CompanyPositionsCareerMapDetail(int careerMapId)
        {
            var ret = _service.LoadCompanyPositionsFromCareerMapId(careerMapId);
            return View(ret);
        }

        public ActionResult RequirementsCompanyPositionDetail(int careerMapId, int companyPositionId)
        {
            var ret = _service.LoadRequirementsFromCompanyPositionId(careerMapId, companyPositionId);
            return View(ret);
        }

        [HttpGet]
        public ActionResult Create()
        {
            return View();
        }

        [HttpPost]
        public ActionResult Create(CareerMapResponse careerMap)
        {
            var ret = _service.Insert(careerMap);
            if (ret)
            {
                return RedirectToAction("Index");
            }
            else
            {
                return View();
            }
        }
    }
}

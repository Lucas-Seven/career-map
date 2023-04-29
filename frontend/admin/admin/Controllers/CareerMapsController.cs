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

        public CareerMapsController()
        {
            _service = new CareerMapsService();
            
        }

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

        [HttpGet]
        public ActionResult AssociatePositions(int careerMapId)
        {
            var availablePositions = new List<CompanyPositionInfo>();
            var unavailablePositions = new List<CompanyPositionInfo>();
            var init = new CompanyPositionListResponse();
            var career = _service.GetAllCareers().Find(x => x.CareerMapId == careerMapId);

            if(career != null)
            {
                try
                {
                    var _serviceCompanyPosition = new CompanyPositionService();

                    var existingPositions = _service.LoadCompanyPositionsFromCareerMapId(careerMapId);
                    var all = _serviceCompanyPosition.GetAllPositions();

                    foreach (var pos in all)
                    {
                        var info = new CompanyPositionInfo()
                        {
                            CompanyPositionId = pos.CompanyPositionId,
                            CompanyPositionName = pos.CompanyPositionName
                        };

                        if (existingPositions.CompanyPositionResponseList.Find(x => x.CompanyPositionInfo.CompanyPositionId == pos.CompanyPositionId) != null)
                        {
                            unavailablePositions.Add(info);
                        }
                        else
                        {
                            availablePositions.Add(info);
                        }
                    }

                }
                catch (Exception) { /* throw; */ }
            }

            ViewBag.AvailablePositions = availablePositions;
            ViewBag.UnavailablePositions = unavailablePositions;

            init.CareerMapResponse = career == null ? new CareerMapResponse() : career;
            
            return View(init);
        }

        [HttpPost]
        public ActionResult AssociatePositions(CompanyPositionListResponse positions)
        {
            var ret = _service.AssociatePositions(positions);
            if (ret)
            {
                return RedirectToAction("CompanyPositionsCareerMapDetail", new { careerMapId = positions.CareerMapResponse.CareerMapId });
            }
            else
            {
                return View();
            }
        }
    }
}

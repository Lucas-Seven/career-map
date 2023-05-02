using admin.Api.Model.Response;
using admin.Services;
using admin.ViewModels;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using api = admin.Api.Service;

namespace admin.Controllers
{
    public class CompanyPositionController : Controller
    {
        private CompanyPositionService _service { get; set; }

        public CompanyPositionController()
        {
            _service = new CompanyPositionService();
        }


        // GET: CarrermapsController
        public ActionResult Index()
        {
            return View(_service.GetAllPositions());
        }

        [HttpGet]
        public ActionResult Create()
        {
            return View();
        }

        [HttpPost]
        public ActionResult Create(CompanyPositionInfo companyPosition)
        {
            var ret = _service.Insert(companyPosition);
            if (ret)
            {
                return RedirectToAction("Index");
            }
            else
            {
                return View();
            }
        }

        //        [HttpGet]
        //public ActionResult AssociateRequirements(int careerMapId, int companyPositionId)
        //{
        //    var availableRequirements = new List<CompanyPositionInfo>();
        //    var unavailableRequirements = new List<CompanyPositionInfo>();
        //    var init = new CompanyPositionListResponse();
        //    var position = _service.GetAllPositions().Find(x => x.CompanyPositionId == companyPositionId && x.ParentCareerMapVm.CareerMapId == careerMapId);

        //    if (position != null)
        //    {
        //        try
        //        {
        //            var _serviceCompanyPosition = new CompanyPositionService();

        //            var existingPositions = _service.LoadCompanyPositionsFromCareerMapId(careerMapId);
        //            var all = _serviceCompanyPosition.GetAllPositions();

        //            foreach (var pos in all)
        //            {
        //                var info = new CompanyPositionInfo()
        //                {
        //                    CompanyPositionId = pos.CompanyPositionId,
        //                    CompanyPositionName = pos.CompanyPositionName
        //                };

        //                if (existingPositions.CompanyPositionResponseList.Find(x => x.CompanyPositionInfo.CompanyPositionId == pos.CompanyPositionId) != null)
        //                {
        //                    unavailableRequirements.Add(info);
        //                }
        //                else
        //                {
        //                    availableRequirements.Add(info);
        //                }
        //            }

        //        }
        //        catch (Exception) { /* throw; */ }
        //    }

        //    ViewBag.AvailablePositions = availableRequirements;
        //    ViewBag.UnavailablePositions = unavailableRequirements;

        //    init.CareerMapResponse = position == null ? new CareerMapResponse() : position;

        //    return View(init);
        //}

        //[HttpPost]
        //public ActionResult AssociatePositions(CompanyPositionListResponse positions)
        //{
        //    var ret = _service.AssociatePositions(positions);
        //    if (ret)
        //    {
        //        return RedirectToAction("CompanyPositionsCareerMapDetail", new { careerMapId = positions.CareerMapResponse.CareerMapId });
        //    }
        //    else
        //    {
        //        return View();
        //    }
        //}
    }
}

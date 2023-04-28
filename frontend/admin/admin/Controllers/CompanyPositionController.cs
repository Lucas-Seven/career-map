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
    }
}

using admin.Api.Model;
using admin.Api.Service;
using admin.Services;
using admin.ViewModels;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;

namespace admin.Controllers
{
    public class QuestionsController : Controller
    {
        private Services.QuestionService _service { get; set; }

        public QuestionsController()
        {
            _service = new Services.QuestionService();
        }

        public ActionResult Details(int questionId)
        {
            return View(_service.GetQuestionById(questionId));
        }

        //public ActionResult Create(int testId)
        [HttpGet]
        public ActionResult Create(int testId)
        {
            //ViewBag.testId = testId;
            AddQuestionVm questionModel = new AddQuestionVm() { IdTest = testId };
            return View(questionModel);
        }

        //public ActionResult Create(QuestionsAlternative question)
        [HttpPost]
        public ActionResult Create(AddQuestionVm questionModel)
        {


            //var idTest = (Int32) ViewData["testId"];
            //ViewBag.testId = idTest;
            //, int testId

            //ViewBag.testId = 305;//testId;
            var res = _service.Insert(questionModel);

            if (res)
            {
                return RedirectToAction("Details", "Tests", new { testId = questionModel.IdTest});
            }

            return View(questionModel);
        }




        // GET: CarrermapsController
        //public ActionResult Index()
        //{
        //    return View(_service.GetAllRequirements());
        //}

        //[HttpGet]
        //public ActionResult Create()
        //{
        //    return View();
        //}

        //[HttpPost]
        //public ActionResult Create(RequirementInfo requirement)
        //{
        //    var ret = _service.AddRequirement(requirement);
        //    if (ret)
        //    {
        //        return RedirectToAction("Index");
        //    }
        //    else
        //    {
        //        return View();
        //    }
        //}



        ////private CompanyPositionService _service { get; set; }

        //public RequirementsController()
        //{
        //_service = new CompanyPositionService();
        //}

        //// GET: CompanyPositionController
        //public ActionResult Index() 
        //{
        //IEnumerable<CompanyPositionVM> positions;
        //try
        //{
        //    CompanyPositionListVM cmCompanyPositions = _service.GetAllCompanyPositions().Result;
        //    //lblBreadcrumb.Text = $"{cmCompanyPositions.CareerMapVm.CareerMapName}";

        //    positions = new List<CompanyPositionVM>(cmCompanyPositions.CompanyPositionVmList);
        //}
        //catch (Exception)
        //{
        //    positions = new List<CompanyPositionVM>();
        //    ModelState.AddModelError(string.Empty, "Erro no servidor. Contate o Administrador.");
        //}

        //    return View("This is index");
        //}

        ////public ActionResult Index(int careerId) 
        ////{
        ////    IEnumerable<CompanyPositionVM> positions;
        ////    try
        ////    {
        ////        CompanyPositionListVM cmCompanyPositions = _service.GetAllCompanyPositions().Result;
        ////        //lblBreadcrumb.Text = $"{cmCompanyPositions.CareerMapVm.CareerMapName}";

        ////        positions = new List<CompanyPositionVM>(cmCompanyPositions.CompanyPositionVmList);
        ////    }
        ////    catch (Exception)
        ////    {
        ////        positions = new List<CompanyPositionVM>();
        ////        ModelState.AddModelError(string.Empty, "Erro no servidor. Contate o Administrador.");
        ////    }

        ////    return View(positions);
        ////}





        //public ActionResult Index0()
        //{
        //    //return View(_service);

        //    IEnumerable<CompanyPositionService> contatos = null;

        //    using (var client = new HttpClient())
        //    {
        //        client.BaseAddress = new Uri("https://localhost:7149/api/careerMaps/1/companyPositions");

        //        //HTTP GET
        //        var responseTask = client.GetAsync("contatos");
        //        responseTask.Wait();
        //        var result = responseTask.Result;

        //        if (result.IsSuccessStatusCode)
        //        {
        //            var readTask = result.Content.ReadAsAsync<IList<CompanyPositionService>>();
        //            readTask.Wait();
        //            contatos = readTask.Result;
        //        }
        //        else
        //        {
        //            contatos = Enumerable.Empty<CompanyPositionService>();
        //            ModelState.AddModelError(string.Empty, "Erro no servidor. Contate o Administrador.");
        //        }
        //        return View(contatos);
        //    }
        //}    

        //// GET: CompanyPositionController/Details/5
        //public ActionResult Informacao(int id)
        //{
        //    return View();
        //}

        //// GET: CompanyPositionController/Create
        //public ActionResult Create()
        //{
        //    return View();
        //}

        //// POST: CompanyPositionController/Create
        //[HttpPost]
        //[ValidateAntiForgeryToken]
        //public ActionResult Create(IFormCollection collection)
        //{
        //    try
        //    {
        //        return RedirectToAction(nameof(Index));
        //    }
        //    catch
        //    {
        //        return View();
        //    }
        //}

        //// GET: CompanyPositionController/Edit/5
        //public ActionResult Edit(int id)
        //{
        //    return View();
        //}

        //// POST: CompanyPositionController/Edit/5
        //[HttpPost]
        //[ValidateAntiForgeryToken]
        //public ActionResult Edit(int id, IFormCollection collection)
        //{
        //    try
        //    {
        //        return RedirectToAction(nameof(Index));
        //    }
        //    catch
        //    {
        //        return View();
        //    }
        //}

        //// GET: CompanyPositionController/Delete/5
        //public ActionResult Delete(int id)
        //{
        //    return View();
        //}

        //// POST: CompanyPositionController/Delete/5
        //[HttpPost]
        //[ValidateAntiForgeryToken]
        //public ActionResult Delete(int id, IFormCollection collection)
        //{
        //    try
        //    {
        //        return RedirectToAction(nameof(Index));
        //    }
        //    catch
        //    {
        //        return View();
        //    }
        //}
    }
}

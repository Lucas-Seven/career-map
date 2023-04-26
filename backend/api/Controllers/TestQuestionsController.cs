using dll.DAL;
using dll.Models;
using viewmodels;
using Microsoft.AspNetCore.Mvc;
using dll.Models.CareerMap;
using viewmodels.Form;
using dll.Models.Form;

namespace api.Controllers
{
    [Route("api/questions")]
    [ApiController]
    public class TestQuestionsController : ControllerBase
    {
        private readonly IConfiguration _configuration;
        private readonly TestQuestionsDAO _testQuestionsDAO;
        public string ConnectionString { get; set; }
        public TestQuestionsController(IConfiguration configuration)
        {
            _configuration = configuration;
            ConnectionString = _configuration.GetConnectionString("AprovAtosConnection");
            _testQuestionsDAO = new TestQuestionsDAO(ConnectionString);
        }

        [HttpPost]
        [Route("insert")]
        public IActionResult PostQuestion(MQuestion question)
        {
            var ret = _testQuestionsDAO.Insert(question);
            //_testQuestionsDAO.InsertTest(test);
            //return Ok(new { message = "The company position was successfully registered into career map." });
            return Ok(ret);
        }

        //[HttpPost]
        //[Route("insert")]
        //public IActionResult PostTest(MTest test)
        //{
        //    var ret = _testQuestionsDAO.InsertTest(test);
        //    //_testQuestionsDAO.InsertTest(test);
        //    //return Ok(new { message = "The company position was successfully registered into career map." });
        //    return Ok(ret);
        //}

        //[HttpPost]
        ////[Route("{careerMapId}/companyPositions/insert")]
        //[Route("insertEntire")]
        //public IActionResult PostTestEntire(VMTestEntire test)
        //{
        //    //_testQuestionsDAO.InsertTest(test);
        //    //return Ok(new { message = "The company position was successfully registered into career map." });
        //    return Ok(new { message = "Need implementation" });
        //}
    }
}

using dll.DAL;
using dll.Models;
using viewmodels;
using Microsoft.AspNetCore.Mvc;
using dll.Models.CareerMap;
using viewmodels.Form;
using dll.Models.Form;
using System.Diagnostics.CodeAnalysis;

namespace api.Controllers
{
    [Route("api/questions")]
    [ApiController]
    public class TestQuestionsController : ControllerBase
    {
        private readonly IConfiguration _configuration;
        private readonly TestQuestionsDAO _dao;
        public string ConnectionString { get; set; }
        public TestQuestionsController(IConfiguration configuration)
        {
            _configuration = configuration;
            ConnectionString = _configuration.GetConnectionString("AprovAtosConnection");
            _dao = new TestQuestionsDAO(ConnectionString);
        }

        [HttpPost]
        [Route("insert")]
        public IActionResult PostQuestion(MQuestion question)
        {
            var ret = _dao.Insert(question);
            //_testQuestionsDAO.InsertTest(test);
            //return Ok(new { message = "The company position was successfully registered into career map." });
            return Ok(ret);
        }

        [HttpPost]
        [Route("insertOnTest")]
        public IActionResult SaveQuestionOnTest(int testId, int questionId)
        {
            //if (question != null)
            //{
            //    var ret = _dao.Insert(question);

            //    if (ret != null && ret.QuestionId>0)
            //    {
            //        var _daoTest = new TestQuestionsOnTestesDAO(ConnectionString);

            //        _daoTest.AssociateQuestionInTest(testId, ret.QuestionId);
            //    }
            //}
            if (testId > 0 )
            {
                if (questionId > 0)
                {
                    var _daoTest = new TestQuestionsOnTestesDAO(ConnectionString);
                    _daoTest.AssociateQuestionInTest(testId, questionId);
                    return Ok();
                }
            }

            //_testQuestionsDAO.InsertTest(test);
            //return Ok(new { message = "The company position was successfully registered into career map." });
            return NoContent();
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

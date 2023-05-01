using dll.DAL;
using dll.Models;
using viewmodels;
using Microsoft.AspNetCore.Mvc;
using dll.Models.CareerMap;
using Microsoft.VisualBasic;
using dll.Models.Form;

namespace api.Controllers
{
    [Route("api/testAnswers")]
    [ApiController]
    public class TestAnswersController : ControllerBase
    {
        private readonly IConfiguration _configuration;
        private readonly TestAnswersDAO _dao;
        public string ConnectionString { get; set; }
        public TestAnswersController(IConfiguration configuration)
        {
            _configuration = configuration;
            ConnectionString = _configuration.GetConnectionString("AprovAtosConnection");
            _dao = new TestAnswersDAO(ConnectionString);
        }

        //[HttpPost]
        //[Route("insert")]
        //public IActionResult PostCareerMap(List<MTestAnswer> answers)
        //{
        //    _dao.InsertCareerMap(careerMap);
        //    return Ok(new { message = "The career map was successfully registered." });
        //}
    }
}

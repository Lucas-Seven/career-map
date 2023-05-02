using dll.DAL;
using dll.Models;
using viewmodels;
using Microsoft.AspNetCore.Mvc;
using dll.Models.CareerMap;
using viewmodels.CareerMap;
using viewmodels.Form;

namespace api.Controllers
{
    [Route("api/questionAlternatives")]
    [ApiController]
    public class QuestionAlternativesController : ControllerBase
    {
        private readonly IConfiguration _configuration;
        private readonly QuestionAlternativesDAO _questionAlternativesDAO;
        public string ConnectionString { get; set; }
        public QuestionAlternativesController(IConfiguration configuration)
        {
            _configuration = configuration;
            ConnectionString = _configuration.GetConnectionString("AprovAtosConnection");
            _questionAlternativesDAO = new QuestionAlternativesDAO(ConnectionString);
        }

        [HttpGet]
        public async Task<VMQuestionAlternatives> GetQuestionById(int questionId)
        {
            VMQuestionAlternatives question = _questionAlternativesDAO.GetQuestionById(questionId);
            return question;
        }

        //[HttpGet]
        //public List<VMAlternative Entire> GetAllRequirements()
        //{
        //    List<VMRequirement> requirements = _positionRequirementsDAO.SelectAllRequirements();
        //    return requirements;
        //}

        //[HttpPost]
        //public IActionResult PostRequirement(MRequirement requirement)
        //{
        //    _positionRequirementsDAO.InsertRequirement(requirement);
        //    return Ok(new { message = "The requirement was successfully registered." });
        //}
    }
}

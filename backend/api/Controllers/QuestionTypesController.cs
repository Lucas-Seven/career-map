using dll.DAL;
using dll.Models;
using viewmodels;
using Microsoft.AspNetCore.Mvc;

namespace api.Controllers
{
    [Route("api/questionTypes")]
    [ApiController]
    public class QuestionTypesController : ControllerBase
    {
        private readonly IConfiguration _configuration;
        private readonly QuestionTypesDAO _questionTypesDAO;
        public string ConnectionString { get; set; }
        public QuestionTypesController(IConfiguration configuration)
        {
            _configuration = configuration;
            ConnectionString = _configuration.GetConnectionString("AprovAtosConnection");
            _questionTypesDAO = new QuestionTypesDAO(ConnectionString);
        }
    }
}

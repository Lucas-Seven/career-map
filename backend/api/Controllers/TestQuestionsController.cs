using dll.DAL;
using dll.Models;
using viewmodels;
using Microsoft.AspNetCore.Mvc;

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
    }
}

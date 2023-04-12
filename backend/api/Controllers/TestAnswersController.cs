using dll.DAL;
using dll.Models;
using viewmodels;
using Microsoft.AspNetCore.Mvc;

namespace api.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class TestAnswersController : ControllerBase
    {
        private readonly IConfiguration _configuration;
        private readonly TestAnswersDAO _testAnswersDAO;
        public string ConnectionString { get; set; }
        public TestAnswersController(IConfiguration configuration)
        {
            _configuration = configuration;
            ConnectionString = _configuration.GetConnectionString("AprovAtosConnection");
            _testAnswersDAO = new TestAnswersDAO(ConnectionString);
        }
    }
}

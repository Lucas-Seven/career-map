using dll.DAL;
using dll.Models;
using viewmodels;
using Microsoft.AspNetCore.Mvc;

namespace api.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class TestsController : ControllerBase
    {
        private readonly IConfiguration _configuration;
        private readonly TestsDAO _testsDAO;
        public string ConnectionString { get; set; }
        public TestsController(IConfiguration configuration)
        {
            _configuration = configuration;
            ConnectionString = _configuration.GetConnectionString("AprovAtosConnection");
            _testsDAO = new TestsDAO(ConnectionString);
        }
    }
}

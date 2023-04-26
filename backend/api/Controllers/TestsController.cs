using dll.DAL;
using dll.Models;
using dll.Models.Form;
using Microsoft.AspNetCore.Mvc;
using viewmodels;
using viewmodels.Form;

namespace api.Controllers
{
    [Route("api/tests")]
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

        [HttpGet]
        [Route("requirements/{requirementId}")]
        public ICollection<VMTestEntire> GetTestByRequirementId(int requirementId)
        {
            return _testsDAO.SelectTestByRequirementId(requirementId);
        }

        [HttpGet]
        [Route("{id}")]
        public VMTestEntire GetTestById(int id)
        {
            return _testsDAO.SelectTestById(id);
        }

        [HttpPost]
        [Route("insert")]
        public IActionResult PostTest(MTest test)
        {
            var ret = _testsDAO.Insert(test);
            return Ok(ret);
        }
    }
}

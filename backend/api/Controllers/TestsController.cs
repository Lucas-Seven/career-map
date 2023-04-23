using dll.DAL;
using dll.Models;
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
        public VMTestEntire GetTestByRequirementId(int requirementId)
        {
            return _testsDAO.SelectTestByRequirementId(requirementId);
        }

        [HttpGet]
        [Route("{id}")]
        public VMTestEntire GetTestById(int id)
        {
            return _testsDAO.SelectTestById(id);
        }
    }
}

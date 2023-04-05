using dll.DAL;
using dll.Data;
using dll.Models;
using dll.ViewModels;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;

namespace api.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class TestsController : ControllerBase
    {
        private readonly TestsDao _testsDao;

        public TestsController(AprovAtosContext context)
        {
            _testsDao = new TestsDao(context);
        }

        [HttpGet]
        public IEnumerable<TestVM> GetAllTests()
        {
            return _testsDao.ListTests();
        }

        [HttpGet("{idRequirement}")]
        public IEnumerable<TestVM> GetTest(int idRequirement)
        {
            return _testsDao.TestById(idRequirement);
        }
    }
}

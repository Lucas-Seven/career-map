using dll.DAL;
using dll.Models;
using viewmodels;
using Microsoft.AspNetCore.Mvc;
using dll.Models.CareerMap;
using viewmodels.CareerMap;

namespace api.Controllers
{
    [Route("api/companyPositions")]
    [ApiController]
    public class CompanyPositionsController : ControllerBase
    {
        private readonly IConfiguration _configuration;
        private readonly CompanyPositionsDAO _companyPositionsDAO;
        public string ConnectionString { get; set; }
        public CompanyPositionsController(IConfiguration configuration)
        {
            _configuration = configuration;
            ConnectionString = _configuration.GetConnectionString("AprovAtosConnection");
            _companyPositionsDAO = new CompanyPositionsDAO(ConnectionString);
        }

        [HttpGet]
        public List<VMCompanyPosition> GetAllCompanyPositions()
        {
            List<VMCompanyPosition> companyPositions = _companyPositionsDAO.SelectAllCompanyPositions();
            return companyPositions;
        }

        [HttpPost]
        public IActionResult PostCompanyPosition(MCompanyPosition companyPosition)
        {
            _companyPositionsDAO.InsertCompanyPosition(companyPosition);
            return Ok(new { message = "The company position was successfully registered." });
        }

        [HttpPost]
        [Route("{companyPositionId}/requirements/insert")]
        public IActionResult PostRequirementInCompanyPosition(MCompanyPositionRequirement companyPositionRequirement)
        {
            _companyPositionsDAO.InsertRequirementInCompanyPosition(companyPositionRequirement);
            return Ok(new { message = "The requirement was successfully registered into company position." });
        }
    }
}

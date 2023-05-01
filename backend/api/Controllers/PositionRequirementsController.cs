using dll.DAL;
using dll.Models;
using viewmodels;
using Microsoft.AspNetCore.Mvc;
using dll.Models.CareerMap;
using viewmodels.CareerMap;

namespace api.Controllers
{
    [Route("api/requirements")]
    [ApiController]
    public class PositionRequirementsController : ControllerBase
    {
        private readonly IConfiguration _configuration;
        private readonly PositionRequirementsDAO _positionRequirementsDAO;
        public string ConnectionString { get; set; }
        public PositionRequirementsController(IConfiguration configuration)
        {
            _configuration = configuration;
            ConnectionString = _configuration.GetConnectionString("AprovAtosConnection");
            _positionRequirementsDAO = new PositionRequirementsDAO(ConnectionString);
        }

        [HttpGet]
        public List<VMRequirement> GetAllRequirements()
        {
            List<VMRequirement> requirements = _positionRequirementsDAO.SelectAllRequirements();
            return requirements;
        }

        [HttpPost]
        public IActionResult PostRequirement(MRequirement requirement)
        {
            _positionRequirementsDAO.InsertRequirement(requirement);
            return Ok(new { message = "The requirement was successfully registered." });
        }


        //[HttpGet]
        //[Route("{careerMapId}/companyPositions/{companyPositionId}/requirements")]
        //public VMCareerMapEntire GetCareerMapEntireById(int careerMapId, int companyPositionId)
        //{
        //    return _careerMapsDAO.SelectCareerMapEntireById(careerMapId, companyPositionId);
        //}
    }
}

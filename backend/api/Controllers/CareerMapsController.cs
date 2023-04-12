using dll.DAL;
using dll.Models;
using viewmodels;
using Microsoft.AspNetCore.Mvc;

namespace api.Controllers
{
    [Route("api/careerMaps")]
    [ApiController]
    public class CareerMapsController : ControllerBase
    {
        private readonly IConfiguration _configuration;
        private readonly CareerMapsDAO _careerMapsDAO;
        private readonly CompanyPositionsDAO _companyPositionsDAO;
        public string ConnectionString { get; set; }
        public CareerMapsController(IConfiguration configuration)
        {
            _configuration = configuration;
            ConnectionString = _configuration.GetConnectionString("AprovAtosConnection");
            _careerMapsDAO = new CareerMapsDAO(ConnectionString);
            _companyPositionsDAO = new CompanyPositionsDAO(ConnectionString);
        }

        [HttpGet]
        [Route("{careerMapId}/companyPositions")]
        public CareerMapCompanyPositionsVM GetCareerMapByIdWithCompanyPositions(int careerMapId)
        {
            return _careerMapsDAO.SelectCareerMapByIdWithCompanyPositions(careerMapId);
        }

        [HttpGet]
        [Route("{careerMapId}/companyPositions/{companyPositionId}/requirements")]
        public CompanyPositionRequirementsVM GetCompanyPositionByIdWithRequirements(int careerMapId, int companyPositionId)
        {
            return _companyPositionsDAO.SelectCompanyPositionByIdWithRequirements(careerMapId, companyPositionId);
        }
    }
}

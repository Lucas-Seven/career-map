using dll.DAL;
using dll.Models;
using Microsoft.AspNetCore.Mvc;
using viewmodels;
using viewmodels.CareerMap;

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
        public List<VMCareerMap> GetAllCareerMaps()
        {
            List<VMCareerMap> careerMaps = _careerMapsDAO.SelectAllCareerMaps();
            return careerMaps;
        }


        [HttpGet]
        [Route("{careerMapId}/companyPositions")]
        public VMCareerMapCompanyPositions GetCareerMapByIdWithCompanyPositions(int careerMapId)
        {
            return _careerMapsDAO.SelectCareerMapByIdWithCompanyPositions(careerMapId);
        }

        [HttpGet]
        [Route("{careerMapId}/companyPositions/{companyPositionId}/requirements")]
        public VMCareerMapEntire GetCompanyPositionByIdWithRequirements(int careerMapId, int companyPositionId)
        {
            return _companyPositionsDAO.SelectCompanyPositionByIdWithRequirements(careerMapId, companyPositionId);
        }
    }
}

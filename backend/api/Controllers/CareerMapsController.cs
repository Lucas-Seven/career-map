using dll.DAL;
using dll.Models;
using dll.ViewModels;
using Microsoft.AspNetCore.Mvc;

namespace api.Controllers
{
    [Route("api/careerMaps")]
    [ApiController]
    public class CareerMapsController : ControllerBase
    {
        private readonly IConfiguration _configuration;
        private readonly CareerMapsDAO _careerMapsDAO;
        public string ConnectionString { get; set; }
        public CareerMapsController(IConfiguration configuration)
        {
            _configuration = configuration;
            ConnectionString = _configuration.GetConnectionString("AprovAtosConnection");
            _careerMapsDAO = new CareerMapsDAO(ConnectionString);
        }

        [HttpGet]
        [Route("{careerMapId}/companyPositions")]
        public CareerMapCompanyPositionsVM GetCareerMapByIdWithCompanyPositions(int careerMapId)
        {
            return _careerMapsDAO.SelectCareerMapByIdWithCompanyPositions(careerMapId);
        }
    }
}

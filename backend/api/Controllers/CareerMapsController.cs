using dll.DAL;
using dll.Models;
using dll.Models.CareerMap;
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
        public string ConnectionString { get; set; }
        public CareerMapsController(IConfiguration configuration)
        {
            _configuration = configuration;
            ConnectionString = _configuration.GetConnectionString("AprovAtosConnection");
            _careerMapsDAO = new CareerMapsDAO(ConnectionString);
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

        [HttpPost]
        [Route("{careerMapId}/companyPositions")]
        public VMCareerMapCompanyPositions AddCompanyPositionToCareer(VMCareerMapCompanyPositions positions)
        {
            return _careerMapsDAO.AddCompanyPositionToCareer(positions);
        }

        [HttpGet]
        [Route("{careerMapId}/companyPositions/{companyPositionId}/requirements")]
        public VMCareerMapEntire GetCareerMapEntireById(int careerMapId, int companyPositionId)
        {
            return _careerMapsDAO.SelectCareerMapEntireById(careerMapId, companyPositionId);
        }

        [HttpPost]
        [Route("insert")]
        public IActionResult PostCareerMap(MCareerMap careerMap)
        {
            _careerMapsDAO.InsertCareerMap(careerMap);
            return Ok(new { message = "The career map was successfully registered." });
        }

        [HttpPost]
        //[Route("{careerMapId}/companyPositions/insert")]
        [Route("companyPositions/insert")]
        public IActionResult PostCompanyPositionInCareerMap(MCareerMapCompanyPosition careerMapCompanyPosition)
        {
            _careerMapsDAO.InsertCompanyPositionInCareerMap(careerMapCompanyPosition);
            return Ok(new { message = "The company position was successfully registered into career map." });
        }
    }
}

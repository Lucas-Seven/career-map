using dll.DAL;
using dll.Data;
using dll.Models;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;

namespace api.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class CareerMapController : ControllerBase
    {
        private readonly CareerMapsDao _careerMapsDao;

        public CareerMapController(CareerMapContext context)
        {
            _careerMapsDao = new CareerMapsDao(context);
        }

        [HttpGet]
        public IEnumerable<CareerMap> GetAllCareerMaps()
        {
            return _careerMapsDao.List();
        }
    }
}

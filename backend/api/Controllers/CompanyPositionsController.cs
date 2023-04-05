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
    public class CompanyPositionsController : ControllerBase
    {
        private readonly CompanyPositionsDao _companyPositionsDao;

        public CompanyPositionsController(CareerMapContext context)
        {
            _companyPositionsDao = new CompanyPositionsDao(context);
        }

        [HttpGet]
        public IEnumerable<CompanyPosition> GetAllCompanyPositions()
        {
            return _companyPositionsDao.List();
        }

        [HttpGet("{idCareerMap}")]
        public IEnumerable<CareerMapCompanyPositionsVM> GetCompanyPositionsByCareerMap(int idCareerMap)
        {
            return _companyPositionsDao.ListCompanyPositionsByCareerMap(idCareerMap);
        }
    }
}

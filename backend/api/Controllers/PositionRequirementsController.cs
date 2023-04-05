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
    public class PositionRequirementsController : ControllerBase
    {
        private readonly PositionRequirementsDao _positionRequirementsDao;

        public PositionRequirementsController(AprovAtosContext context)
        {
            _positionRequirementsDao = new PositionRequirementsDao(context);
        }

        [HttpGet]
        public IEnumerable<PositionRequirement> GetAllPositionRequirements()
        {
            return _positionRequirementsDao.List();
        }

        [HttpGet("{idCompanyPosition}")]
        public IEnumerable<CompanyPositionRequirementsVM> GetRequirementsByCompanyPosition(int idCompanyPosition)
        {
            return _positionRequirementsDao.ListRequirementsByCompanyPosition(idCompanyPosition);
        }
    }
}

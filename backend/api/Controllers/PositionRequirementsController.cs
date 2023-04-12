using dll.DAL;
using dll.Models;
using viewmodels;
using Microsoft.AspNetCore.Mvc;

namespace api.Controllers
{
    [Route("api/positionRequirements")]
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
    }
}

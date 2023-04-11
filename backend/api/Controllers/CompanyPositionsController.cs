using dll.DAL;
using dll.ViewModels;
using Microsoft.AspNetCore.Mvc;

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
    }
}

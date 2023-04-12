using dll.DAL;
using dll.Models;
using Microsoft.AspNetCore.Mvc;
using viewmodels.ViewModels;

namespace api.Controllers
{
    [Route("api/users")]
    [ApiController]
    public class UsersController : ControllerBase
    {
        private readonly IConfiguration _configuration;
        private readonly UsersDAO _usersDAO;
        public string ConnectionString { get; set; }
        public UsersController(IConfiguration configuration)
        {
            _configuration = configuration;
            ConnectionString = _configuration.GetConnectionString("AprovAtosConnection");
            _usersDAO = new UsersDAO(ConnectionString);
        }

        [HttpGet]
        [Route("accessTypes")]
        public List<UserAccessTypesVM> GetAllUsersWithAccessTypes()
        {
            List<UserAccessTypesVM> users = _usersDAO.SelectAllUsersWithAccessTypes();
            return users;
        }

        [HttpGet]
        [Route("{userId}/accessTypes")]
        public UserAccessTypesVM GetUserByIdWithAccessTypes(int userId)
        {
            return _usersDAO.SelectUserByIdWithAccessTypes(userId);
        }

        [HttpPost]
        public IActionResult PostUser([FromBody] UserModel user)
        {
            _usersDAO.InsertUser(user);
            return Ok();
        }
    }
}

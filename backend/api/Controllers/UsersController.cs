using dll.DAL;
using dll.Models;
using Microsoft.AspNetCore.Mvc;

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
        public List<UserModel> GetAllUsers()
        {
            List<UserModel> users = _usersDAO.SelectAllUsers();
            return users;
        }

        [HttpGet]
        [Route("{userId}/accessTypes")]
        public UserModel GetUserById(int userId)
        {
            return _usersDAO.SelectUser(userId);
        }

        [HttpPost]
        public IActionResult PostUser([FromBody] UserModel user)
        {
            _usersDAO.InsertUser(user);
            return Ok();
        }
    }
}

using dll.DAL;
using dll.Models;
using Microsoft.AspNetCore.Mvc;
using viewmodels.User;

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
        public List<VMUser> GetAllUsers()
        {
            List<VMUser> users = _usersDAO.SelectAllUsers();
            return users;
        }

        [HttpGet]
        [Route("{userId}")]
        public VMUser GetUserById(int userId)
        {
            return _usersDAO.SelectUserById(userId);
        }

        [HttpGet]
        [Route("{userId}/careerMap")]
        public VMUserCareerMap GetUserByIdWithCareerMap(int userId)
        {
            return _usersDAO.SelectUserByIdWithCareerMap(userId);
        }
        
        [HttpGet]
        [Route("{userId}/accessTypes")]
        public VMUserAccessTypes GetUserByIdWithAccessTypes(int userId)
        {
            return _usersDAO.SelectUserByIdWithAccessTypes(userId);
        }

        [HttpGet]
        [Route("{userId}/careerMap/accessTypes")]
        public VMUserEntire GetUserEntireById(int userId)
        {
            return _usersDAO.SelectUserEntireById(userId);
        }

        //[HttpGet]
        //[Route("{userId}/accessTypes")]
        //public VMUserEntire GetUserByIdWithAccessTypes(int userId)
        //{
        //    return _usersDAO.SelectUserByIdWithAccessTypes(userId);
        //}

        //[HttpPost]
        //public IActionResult PostUser([FromBody] MUser user)
        //{
        //    _usersDAO.InsertUser(user);
        //    return Ok();
        //}
    }
}

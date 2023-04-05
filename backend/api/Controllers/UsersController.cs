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
    public class UsersController : ControllerBase
    {
        private readonly UsersDao _usersDao;

        public UsersController(AprovAtosContext context)
        {
            _usersDao = new UsersDao(context);
        }

        [HttpGet]
        public IEnumerable<User> GetAllUsers()
        {
            return _usersDao.List();
        }

        [HttpGet("{idUser}")]
        public IEnumerable<UserProfileVM> GetUser(int idUser)
        {
            return _usersDao.UserById(idUser);
        }
    }
}

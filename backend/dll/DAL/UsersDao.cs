using dll.Data;
using dll.Models;
using dll.ViewModels;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace dll.DAL
{
    public class UsersDao : GenericDao<User>
    {
        public UsersDao(AprovAtosContext context) : base(context)
        { 
            this.Context = context;
        }

        public IEnumerable<UserProfileVM> UserById(int idUser)
        {
            var obj = Context.Users.Join(
                Context.CareerMaps,
                u => u.career_map_id,
                c => c.career_map_id,
                (u, c) => new { User = u, CareerMap = c }
            )
            .Join(
                Context.AccessTypes_Users,
                uc => uc.User.user_id,
                au => au.user_id,
                (uc, au) => new { User = uc.User, CareerMap = uc.CareerMap, AccessType_User = au }
            )
            .Join(
                Context.AccessTypes,
                ucau => ucau.AccessType_User.access_type_id,
                a => a.access_type_id,
                (ucau, a) => new UserProfileVM
                {
                    user_id = ucau.User.user_id,
                    first_name = ucau.User.first_name,
                    last_name = ucau.User.last_name,
                    email = ucau.User.email,
                    career_map_id = ucau.CareerMap.career_map_id,
                    career_map_name = ucau.CareerMap.career_map_name,
                    access_type_id = a.access_type_id,
                    access_type_name = a.access_type_name
                }
            )
            .Where(
                w => w.user_id == idUser
            );

            return obj;
        }
    }
}

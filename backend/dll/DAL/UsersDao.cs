using dll.Data;
using dll.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace dll.DAL
{
    public class UsersDao : GenericDao<User>
    {
        public UsersDao(CareerMapContext context) : base(context)
        { }
    }
}

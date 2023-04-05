using dll.Data;
using dll.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace dll.DAL
{
    public class AccessTypes_UsersDao : GenericDao<AccessType_User>
    {
        public AccessTypes_UsersDao(AprovAtosContext context) : base(context)
        { }
    }
}

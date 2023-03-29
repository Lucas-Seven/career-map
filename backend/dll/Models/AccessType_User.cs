using Dapper.Contrib.Extensions;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace dll.Models
{
    [Table("accessTypes_users_tb")]
    public class AccessType_User
    {
        public int user_id { get; set; }
        public int access_type_id { get; set; }
    }
}

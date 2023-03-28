using Dapper.Contrib.Extensions;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace dll.Models
{
    [Table("users_tb")]
    internal class User
    {
        [Key]
        public int user_id { get; set; }
        public int? career_map_id { get; set; }
        public string first_name { get; set; }
        public string last_name { get; set; }
        public string email { get; set; }
        public string password_hash { get; set; }
    }
}

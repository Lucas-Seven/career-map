using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace dll.ViewModels
{
    public class UserProfileVM
    {
        public int user_id { get; set; }
        public string first_name { get; set; }
        public string last_name { get; set; }
        public string email { get; set; }
        public int? career_map_id { get; set; }
        public string? career_map_name { get; set; }
        public int access_type_id { get; set; }
        public string access_type_name { get; set; }
    }
}

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
        public string firstName { get; set; }
        public string last_name { get; set; }
        public string email { get; set; }
        public CareerMapVM careerMap { get; set; }

        public ICollection<AccessTypeVM> aceessTypes { get; set; }

        public UserProfileVM()
        {
            aceessTypes = new List<AccessTypeVM>();
        }
    }
}

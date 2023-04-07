using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace dll.ViewModels
{
    public class CompanyPositionRequirementsVM
    {
        public CompanyPositionVM companyPosition { get; set; }
        public string? group_name { get; set; }
        public int requirement_id { get; set; }
        public string requirement_name { get; set; }
    }
}

using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace admin.ViewModels
{
    public class CompanyPositionRequirementsVM
    {
        public int company_position_id { get; set; }
        public string company_position_name { get; set; }
        public string? group_name { get; set; }
        public int requirement_id { get; set; }
        public string requirement_name { get; set; }
    }
}

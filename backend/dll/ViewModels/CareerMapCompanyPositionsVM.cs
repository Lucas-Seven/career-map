using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace dll.ViewModels
{
    public class CareerMapCompanyPositionsVM
    {
        public int career_map_id { get; set; }
        public string career_map_name { get; set; }
        public int company_position_id { get; set; }
        public string company_position_name { get; set; }
        public int hierarchy_number { get; set; }
    }
}

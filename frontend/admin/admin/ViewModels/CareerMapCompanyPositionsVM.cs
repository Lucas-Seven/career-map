using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace admin.ViewModels
{
    public class CareerMapCompanyPositionsVM
    {
        public CareerMapVM CareerMap { get; set; }
        public int company_position_id { get; set; }
        public string company_position_name { get; set; }
        public int hierarchy_number { get; set; }
    }
}

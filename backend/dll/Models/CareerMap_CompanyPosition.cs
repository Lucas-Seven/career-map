using Dapper.Contrib.Extensions;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace dll.Models
{
    [Table("careerMaps_companyPositions_tb")]
    internal class CareerMap_CompanyPosition
    {
        public int career_map_id { get; set; }
        public int company_position_id { get; set; }
        public int hierarchy_number { get; set; }
    }
}

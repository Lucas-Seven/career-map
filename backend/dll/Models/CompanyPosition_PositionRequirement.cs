using Dapper.Contrib.Extensions;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace dll.Models
{
    [Table("companyPositions_positionRequirements_tb")]
    public class CompanyPosition_PositionRequirement
    {
        public int company_position_id { get; set; }
        public int requirement_id { get; set; }
        public string? group_name { get; set; }
    }
}

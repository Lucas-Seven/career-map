using Dapper.Contrib.Extensions;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace dll.Models
{
    [Table("companyPositions_tb")]
    public class CompanyPosition
    {
        [Key]
        public int company_position_id { get; set; }
        public string company_position_name { get; set; }
    }
}

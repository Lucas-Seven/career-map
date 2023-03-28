using Dapper.Contrib.Extensions;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace dll.Models
{
    [Table("positionRequirements_tb")]
    internal class PositionRequirement
    {
        [Key]
        public int requirement_id { get; set; }
        public string requirement_name { get; set; }
    }
}

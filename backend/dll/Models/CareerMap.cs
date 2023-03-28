using Dapper.Contrib.Extensions;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace dll.Models
{
    [Table("careerMaps_tb")]
    internal class CareerMap
    {
        [Key]
        public int career_map_id { get; set; }
        public string career_map_name { get; set; }
    }
}

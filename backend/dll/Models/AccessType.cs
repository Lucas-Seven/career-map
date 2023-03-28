using Dapper.Contrib.Extensions;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace dll.Models
{
    [Table("accessTypes_tb")]
    internal class AccessType
    {
        [Key]
        public int access_type_id { get; set; }
        public string access_type_name { get; set; }
    }
}

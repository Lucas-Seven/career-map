using Dapper.Contrib.Extensions;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace dll.Models
{
    [Table("tests_tb")]
    internal class Test
    {
        [Key]
        public int test_id { get; set; }
        public int requirement_id { get; set; }
        public string? description { get; set; }
    }
}

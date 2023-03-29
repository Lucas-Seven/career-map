using Dapper.Contrib.Extensions;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace dll.Models
{
    [Table("testQuestions_tb")]
    public class TestQuestion
    {
        [Key]
        public int question_id { get; set; }
        public int question_type_id { get; set; }
        public string question { get; set; }
        public bool is_required { get; set; }
        public string? description { get; set; }
    }
}

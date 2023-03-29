using Dapper.Contrib.Extensions;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace dll.Models
{
    [Table("testAnswers_tb")]
    public class TestAnswer
    {
        [Key]
        public int answer_id { get; set; }
        public int user_id { get; set; }
        public int test_id { get; set; }
        public int question_id { get; set; }
        public int? alternative_id { get; set; }
        public string? dissertative_answer { get; set; }
    }
}

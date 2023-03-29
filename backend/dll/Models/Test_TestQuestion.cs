using Dapper.Contrib.Extensions;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace dll.Models
{
    [Table("tests_testQuestions_tb")]
    public class Test_TestQuestion
    {
        public int test_id { get; set; }
        public int question_id { get; set; }
    }
}

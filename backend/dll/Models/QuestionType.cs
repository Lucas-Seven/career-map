using Dapper.Contrib.Extensions;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace dll.Models
{
    [Table("questionTypes_tb")]
    public class QuestionType
    {
        [Key]
        public int question_type_id { get; set; }
        public string question_type_name { get; set; }
    }
}

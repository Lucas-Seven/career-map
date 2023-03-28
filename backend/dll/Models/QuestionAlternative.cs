using Dapper.Contrib.Extensions;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace dll.Models
{
    [Table("questionAlternatives_tb")]
    internal class QuestionAlternative
    {
        [Key]
        public int alternative_id { get; set; }
        public int question_id { get; set; }
        public string alternative { get; set; }
        public bool is_right { get; set; }
    }
}

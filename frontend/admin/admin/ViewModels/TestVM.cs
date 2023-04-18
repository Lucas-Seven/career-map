using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace admin.ViewModels
{
    public class TestVM
    {
        public int test_id { get; set; }
        public string? testDescription { get; set; }
        public int requirement_id { get; set; }
        public string requirement_name { get; set; }
        public int question_id { get; set; }
        public bool is_required { get; set; }
        public string question { get; set; }
        public string? questionDescription { get; set; }
        public int question_type_id { get; set; }
        public string question_type_name { get; set; }
        public int? alternative_id { get; set; }
        public string? alternative { get; set; }
    }
}

using dll.Data;
using dll.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace dll.DAL
{
    public class Tests_TestQuestionsDao : GenericDao<Test_TestQuestion>
    {
        public Tests_TestQuestionsDao(CareerMapContext context) : base(context)
        { }
    }
}

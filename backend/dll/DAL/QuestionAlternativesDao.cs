using dll.Data;
using dll.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace dll.DAL
{
    public class QuestionAlternativesDao : GenericDao<QuestionAlternative>
    {
        public QuestionAlternativesDao(AprovAtosContext context) : base(context)
        { }
    }
}

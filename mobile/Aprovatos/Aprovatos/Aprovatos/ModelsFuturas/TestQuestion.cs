using System.Collections.Generic;

namespace Aprovatos.ModelsFuturas
{
    public class TestQuestion
    {
        public int QuestionId { get; set; }
        public bool IsRequired { get; set; }
        public string Question { get; set; }
        public string Description { get; set; }
        public QuestionType Type { get; set; }
        public ICollection<QuestionAlternative> Alternatives { get; set; }
        public TestQuestion()
        {
            Alternatives = new List<QuestionAlternative>();
        }
    }
}

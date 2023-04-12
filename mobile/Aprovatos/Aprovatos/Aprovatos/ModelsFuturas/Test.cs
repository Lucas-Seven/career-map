using System.Collections.Generic;

namespace Aprovatos.ModelsFuturas
{
    public class Test
    {
        public int TestId { get; set; }
        public string Description { get; set; }
        public PositionRequirement Requirement { get; set; }
        public ICollection<TestQuestion> Questions { get; set; }
        public Test()
        {
            Questions = new List<TestQuestion>();
        }
    }
}

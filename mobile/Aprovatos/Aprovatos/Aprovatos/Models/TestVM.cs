using System.Collections.Generic;

namespace Models
{
    public class TestVM
    {
        public int TestId { get; set; }
        public string Description { get; set; }
        public PositionRequirementVM Requirement { get; set; }
        public ICollection<TestQuestionVM> Questions { get; set; }
        public TestVM()
        {
            Questions = new List<TestQuestionVM>();
        }
    }
}

using dll.Models;

namespace dll.ViewModels
{
    public class TestVM
    {
        public int TestId { get; set; }
        public string? Description { get; set; }
        public PositionRequirementModel Requirement { get; set; }
        public ICollection<TestQuestionVM> Questions { get; set; }
        public TestVM()
        {
            Questions = new List<TestQuestionVM>();
        }
    }
}

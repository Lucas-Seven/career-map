namespace viewmodels
{
    public class TestQuestionVM
    {
        public int QuestionId { get; set; }
        public bool IsRequired { get; set; }
        public string? Question { get; set; }
        public string? Description { get; set; }
        public QuestionTypeVM? Type { get; set; }
        public ICollection<QuestionAlternativeVM> Alternatives { get; set; }
        public TestQuestionVM()
        {
            Alternatives = new List<QuestionAlternativeVM>();
        }
    }
}

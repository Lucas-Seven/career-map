namespace viewmodels.Form
{
    public class VMQuestion
    {
        public int QuestionId { get; set; }
        public bool IsRequired { get; set; }
        public string Question { get; set; }
        public string Description { get; set; }
        public VMQuestionType Type { get; set; }
    }
}

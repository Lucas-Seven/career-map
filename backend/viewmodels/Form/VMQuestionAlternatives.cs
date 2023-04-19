namespace viewmodels.Form
{
    public class VMQuestionAlternatives
    {
        //public VMQuestion Question { get; set; }
        public int QuestionId { get; set; }
        public bool IsRequired { get; set; }
        public string Question { get; set; }
        public string? Description { get; set; }
        public VMQuestionType Type { get; set; }
        public ICollection<VMAlternative> Alternatives { get; set; }
        public VMQuestionAlternatives()
        {
            Alternatives = new List<VMAlternative>();
        }
    }
}

namespace dll.Models.Form
{
    public class MTestAnswer
    {
        public int AnswerId { get; set; }
        public int UserId { get; set; }
        public int TestId { get; set; }
        public int QuestionId { get; set; }
        public string? AlternativeId { get; set; }
        public string? DissertativeAnswer { get; set; }
    }
}

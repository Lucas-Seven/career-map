namespace dll.Models
{
    public class QuestionAlternativeModel
    {
        public int AlternativeId { get; set; }
        public int QuestionId { get; set; }
        public string Alternative { get; set; }

        public bool IsRight { get; set; }
    }
}

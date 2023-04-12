namespace dll.Models
{
    public class QuestionAlternativeVM
    {
        public int AlternativeId { get; set; }
        public int QuestionId { get; set; }
        public string Alternative { get; set; }

        public bool IsRight { get; set; }
    }
}

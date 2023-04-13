namespace dll.Models.Form
{
    public class MAlternative
    {
        public int AlternativeId { get; set; }
        public int QuestionId { get; set; }
        public string Alternative { get; set; }

        public bool IsRight { get; set; }
    }
}

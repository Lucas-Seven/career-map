namespace dll.Models.Form
{
    public class MQuestion
    {
        public int QuestionId { get; set; }
        public int QuestionTypeId { get; set; }
        public string Question { get; set; }
        public bool IsRequired { get; set; }
        public string? Description { get; set; }
    }
}

namespace viewmodels.Form
{
    public class VMQuestionAlternatives
    {
        public VMQuestion Question { get; set; }
        public ICollection<VMAlternative> Alternatives { get; set; }
        public VMQuestionAlternatives()
        {
            Alternatives = new List<VMAlternative>();
        }
    }
}

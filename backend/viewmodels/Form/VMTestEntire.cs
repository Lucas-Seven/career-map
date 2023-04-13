namespace viewmodels.Form
{
    public class VMTestEntire
    {
        public VMTest Test { get; set; }
        public ICollection<VMQuestionAlternatives> QuestionsAlternatives { get; set; }
        public VMTestEntire()
        {
            QuestionsAlternatives = new List<VMQuestionAlternatives>();
        }
    }
}

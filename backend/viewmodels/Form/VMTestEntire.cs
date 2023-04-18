using viewmodels.CareerMap;

namespace viewmodels.Form
{
    public class VMTestEntire
    {
        //public VMTest Test { get; set; }
        public int TestId { get; set; }
        public string? Description { get; set; }
        public VMRequirement Requirement { get; set; }
        public ICollection<VMQuestionAlternatives> QuestionsAlternatives { get; set; }
        public VMTestEntire()
        {
            QuestionsAlternatives = new List<VMQuestionAlternatives>();
        }
    }
}

namespace viewmodels.CareerMap
{
    public class VMCareerMapEntire
    {
        public VMCareerMap CareerMap { get; set; }
        public VMCompanyPosition CompanyPosition { get; set; }
        public ICollection<VMRequirementEntire> Requirements { get; set; }
        public VMCareerMapEntire()
        {
            Requirements = new List<VMRequirementEntire>();
        }
    }
}

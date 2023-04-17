namespace viewmodels.CareerMap
{
    public class VMCompanyPositionRequirements
    {
        public VMCompanyPosition CompanyPosition { get; set; }
        public ICollection<VMRequirementEntire> Requirements { get; set; }
        public VMCompanyPositionRequirements()
        {
            Requirements = new List<VMRequirementEntire>();
        }
    }
}

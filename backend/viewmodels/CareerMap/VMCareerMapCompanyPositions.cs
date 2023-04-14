namespace viewmodels.CareerMap
{
    public class VMCareerMapCompanyPositions
    {
        public VMCareerMap CareerMap { get; set; }
        public ICollection<VMCompanyPositionEntire> CompanyPositions { get; set; }
        public VMCareerMapCompanyPositions()
        {
            CompanyPositions = new List<VMCompanyPositionEntire>();
        }
    }
}

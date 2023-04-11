namespace dll.ViewModels
{
    public class CareerMapCompanyPositionsVM
    {
        public int CareerMapId { get; set; }
        public string? CareerMapName { get; set; }
        public ICollection<CompanyPositionVM>? CompanyPositions { get; set; }
        public CareerMapCompanyPositionsVM()
        {
            CompanyPositions = new List<CompanyPositionVM>();
        }
    }
}

namespace dll.ViewModels
{
    public class CareerMapViewModel
    {
        public int CareerMapId { get; set; }
        public string? CareerMapName { get; set; }
        public ICollection<CompanyPositionViewModel>? CompanyPositions { get; set; }
        public CareerMapViewModel()
        {
            CompanyPositions = new List<CompanyPositionViewModel>();
        }
    }
}

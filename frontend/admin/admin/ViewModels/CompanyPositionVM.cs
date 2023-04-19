namespace admin.ViewModels
{
    public class CompanyPositionVM
    {
        public CareerMapVM ParentCareerMapVm { get; set; }
        public int CompanyPositionId { get; set; }
        public string CompanyPositionName { get; set; }
        public int HierarchyNumber { get; set; }
    }
}

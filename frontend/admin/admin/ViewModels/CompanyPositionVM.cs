using admin.Api.Model.Response;

namespace admin.ViewModels
{
    public class CompanyPositionVM
    {
        public CareerMapResponse ParentCareerMapVm { get; set; }
        public int CompanyPositionId { get; set; }
        public string CompanyPositionName { get; set; }
        public int HierarchyNumber { get; set; }
    }
}

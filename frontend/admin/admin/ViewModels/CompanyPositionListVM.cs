using admin.Api.Model.Response;

namespace admin.ViewModels
{
    public class CompanyPositionListVM
    {
        public CareerMapResponse CareerMapVm { get; set; }

        public ICollection<CompanyPositionVM> CompanyPositionVmList { get; set; }
        public CompanyPositionListVM()
        {
            CompanyPositionVmList = new List<CompanyPositionVM>();
        }
    }
}

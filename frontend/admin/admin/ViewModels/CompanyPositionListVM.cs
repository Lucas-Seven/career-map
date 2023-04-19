namespace admin.ViewModels
{
    public class CompanyPositionListVM
    {
        public CareerMapVM CareerMapVm { get; set; }

        public ICollection<CompanyPositionVM> CompanyPositionVmList { get; set; }
        public CompanyPositionListVM()
        {
            CompanyPositionVmList = new List<CompanyPositionVM>();
        }
    }
}

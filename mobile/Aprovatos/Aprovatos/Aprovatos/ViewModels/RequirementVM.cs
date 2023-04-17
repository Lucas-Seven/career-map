namespace Aprovatos.ViewModels
{
    public class RequirementVM
    {
        public CompanyPositionVM ParentCompanyPositionVm { get; set; }
        public int RequirementId { get; set; }
        public string RequirementName { get; set; }
        public string GroupName { get; set; }
    }
}

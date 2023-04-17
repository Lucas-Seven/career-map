using Aprovatos.ViewModels;
using System;
using System.Collections.Generic;
using System.Text;
using System.Threading.Tasks;
using Xamarin.Forms;
using api = Aprovatos.Api.Service;

namespace Aprovatos.Service
{
    public class RequirementService
    {
        public api.RequirementsService _apiService { get; set; }

        public CompanyPositionVM companyPosition { get; set; }

        public RequirementService(CompanyPositionVM companyPosition) 
        {
            if (companyPosition != null)
            {
                this.companyPosition = companyPosition;
                _apiService = new api.RequirementsService(companyPosition.ParentCareerMapVm.CareerMapId, companyPosition.CompanyPositionId); 
            }
        }

        public async Task<RequirementListVM> GetRequirementsList()
        {
            var data = await _apiService.LoadDataFromApi();

            var companyPosition = new CompanyPositionVM()
            {
                ParentCareerMapVm = new CareerMapVM() {
                    CareerMapId = data.CareerMap.CareerMapId,
                    CareerMapName = data.CareerMap.CareerMapName
                },
                CompanyPositionId = data.CompanyPositionInfo.CompanyPositionId,
                CompanyPositionName = data.CompanyPositionInfo.CompanyPositionName
                //, HierarchyNumber = data.CompanyPosition.HierarchyNumber
            };

            RequirementListVM ret = new RequirementListVM();
            ret.CompanyPosition = companyPosition;

            foreach (var requirement in data.Requirements)
            {
                RequirementVM requirementVm = new RequirementVM()
                {
                    ParentCompanyPositionVm = companyPosition,
                    RequirementId = requirement.RequirementInfo.RequirementId,
                    RequirementName = requirement.RequirementInfo.RequirementName,
                    GroupName = requirement.GroupName
                };

                ret.Requirements.Add(requirementVm);
            }

            return ret;
        }
    }
}

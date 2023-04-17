using Aprovatos.ViewModels;
using System;
using System.Collections.Generic;
using System.Text;
using System.Threading.Tasks;
using Xamarin.Forms;
using api = Aprovatos.Api.Service;

namespace Aprovatos.Service
{
    public class CompanyPositionService
    {
        public api.CompanyPositionService _apiService { get; set; }

        public CareerMapVM careerMap { get; set; }


        public CompanyPositionService(CareerMapVM career) 
        {
            if (career != null)
            {
                this.careerMap = career;
                _apiService = new api.CompanyPositionService(careerMap.CareerMapId); 
            }
        }

        public async Task<CompanyPositionListVM> GetCompanyPositionsList()
        {
            var data = await _apiService.LoadDataFromApi();

            var careerMap = new CareerMapVM()
            {
                CareerMapId = data.CareerMapResponse.CareerMapId,
                CareerMapName = data.CareerMapResponse.CareerMapName
            };

            CompanyPositionListVM ret = new CompanyPositionListVM();
            ret.CareerMapVm = careerMap;

            foreach (var item in data.CompanyPositionResponseList)
            {
                CompanyPositionVM cp = new CompanyPositionVM()
                {
                    ParentCareerMapVm = careerMap,
                    CompanyPositionId = item.CompanyPositionInfo.CompanyPositionId,
                    CompanyPositionName = item.CompanyPositionInfo.CompanyPositionName,
                    HierarchyNumber = item.HierarchyNumber
                };

                ret.CompanyPositionVmList.Add(cp);
            }

            return ret;
        }
    }
}

using admin.Api.Model.Response;
using admin.ViewModels;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore.Metadata.Internal;
using api = admin.Api.Service;

namespace admin.Services
{
    public class CompanyPositionService : Controller
    {
        public api.CompanyPositionService _api;

        public CompanyPositionService()
        {
            _api = new api.CompanyPositionService();
        }

        public List<CompanyPositionVM> GetAllPositions()
        {
            var data = _api.GetAllPositions().Result;
            var ret = new List<CompanyPositionVM>();

            foreach (var item in data)
            {
                CompanyPositionVM career = new CompanyPositionVM()
                {
                    CompanyPositionId = item.CompanyPositionId,
                    CompanyPositionName = item.CompanyPositionName
                };

                ret.Add(career);
            }

            return ret;
        }


        public Dictionary<int, CompanyPositionVM> LoadDataMemory()
        {
            var careers = new Dictionary<int, CompanyPositionVM>();

            for (int i = 1; i <= 5; i++)
            {
                careers.Add(i, new CompanyPositionVM()
                {
                    CompanyPositionId = i,
                    CompanyPositionName = $"Carreira {i}"
                });
            };
            return careers;
        }

        //public api.CompanyPositionService _apiService { get; set; }

        //public CareerMapVM careerMap { get; set; }

        //public CompanyPositionService()
        //{
        //    //if (career != null)
        //    //{
        //        //this.careerMap = career;
        //        _apiService = new api.CompanyPositionService();
        //    //}
        //}

        //public async Task<List<CompanyPositionInfo>> GetAllCompanyPositions()
        //{
        //    var data = await _apiService.GetAllPositions();

        //    List<CompanyPositionVM> ret = new List<CompanyPositionVM>();

        //    foreach (var item in data)
        //    {
        //        CompanyPositionVM cp = new CompanyPositionVM()
        //        {
        //            CompanyPositionId = item.CompanyPositionId,
        //            CompanyPositionName = item.CompanyPositionName,
        //        };

        //        ret.Add(cp);
        //    }

        //    return data;
        //}

        ////public async Task<CompanyPositionListVM> GetCompanyPositionsList()
        ////{
        ////    var data = await _apiService.GetPositionsByCareer();

        ////    var careerMap = new CareerMapVM()
        ////    {
        ////        CareerMapId = data.CareerMapResponse.CareerMapId,
        ////        CareerMapName = data.CareerMapResponse.CareerMapName
        ////    };

        ////    CompanyPositionListVM ret = new CompanyPositionListVM();
        ////    ret.CareerMapVm = careerMap;

        ////    foreach (var item in data.CompanyPositionResponseList)
        ////    {
        ////        CompanyPositionVM cp = new CompanyPositionVM()
        ////        {
        ////            ParentCareerMapVm = careerMap,
        ////            CompanyPositionId = item.CompanyPositionInfo.CompanyPositionId,
        ////            CompanyPositionName = item.CompanyPositionInfo.CompanyPositionName,
        ////            HierarchyNumber = item.HierarchyNumber
        ////        };

        ////        ret.CompanyPositionVmList.Add(cp);
        ////    }

        ////    return ret;
        ////}
    }
}

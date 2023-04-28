using admin.Api.Model.Response;
using admin.ViewModels;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore.Metadata.Internal;
using api = admin.Api.Service;

namespace admin.Services
{
    public class CompanyPositionService
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

        public List<CompanyPositionVM> GetPostionsByCareerId(int id)
        {
            var data = _api.GetPositionsByCareerMap(id).Result;
            var ret = new List<CompanyPositionVM>();

            var careerMap = new CareerMapVM()
            {
                CareerMapId = data.CareerMapResponse.CareerMapId,
                CareerMapName = data.CareerMapResponse.CareerMapName,
            };
                        
            foreach (var item in data.CompanyPositionResponseList.OrderBy(x => x.HierarchyNumber))
            {
                CompanyPositionVM company = new CompanyPositionVM()
                {
                    ParentCareerMapVm = careerMap,
                    CompanyPositionId = item.CompanyPositionInfo.CompanyPositionId,
                    CompanyPositionName = item.CompanyPositionInfo.CompanyPositionName
                };

                ret.Add(company);
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

        public bool Insert(CompanyPositionInfo companyPosition)
        {
            return _api.Insert(companyPosition).Result;
        }
    }
}

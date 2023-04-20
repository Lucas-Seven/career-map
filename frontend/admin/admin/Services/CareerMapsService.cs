using admin.Api.Model.Response;
using admin.ViewModels;
using System.ComponentModel.DataAnnotations;
using api = admin.Api.Service;

namespace admin.Services
{
    public class CareerMapsService
    {
        public api.CareerMapService _api;

        public CareerMapsService()
        {
            _api = new api.CareerMapService();   
        }
        public List<CareerMapVM> GetAllCareers() 
        {
            var data = _api.GetAllCareers().Result;
            var ret = new List<CareerMapVM>();

            foreach (var item in data)
            {
                CareerMapVM career = new CareerMapVM()
                {
                    CareerMapId = item.CareerMapId,
                    CareerMapName = item.CareerMapName
                };

                ret.Add(career);
            }

            return ret;
        }

        public CompanyPositionListVM GetById(int id) 
        {
            var data = _api.GetById(id).Result;
            var ret = new CompanyPositionListVM();

            ret.CareerMapVm = new CareerMapVM()
            {
                CareerMapId = data.CareerMapResponse.CareerMapId,
                CareerMapName = data.CareerMapResponse.CareerMapName
            };

            foreach (var item in data.CompanyPositionResponseList)
            {
                CompanyPositionVM company = new CompanyPositionVM()
                {
                    CompanyPositionId = item.CompanyPositionInfo.CompanyPositionId,
                    CompanyPositionName= item.CompanyPositionInfo.CompanyPositionName
                };

                ret.CompanyPositionVmList.Add(company);
            }

            return ret;
        }


        public Dictionary<int, CareerMapVM> LoadDataMemory()
        {
            var careers = new Dictionary<int, CareerMapVM>();

            for (int i = 1; i <= 5; i++)
            {
                careers.Add(i, new CareerMapVM()
                {
                    CareerMapId = i,
                    CareerMapName = $"Carreira {i}"
                });
            };
            return careers;
        }
    }
}

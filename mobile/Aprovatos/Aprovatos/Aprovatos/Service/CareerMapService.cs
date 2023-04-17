using Aprovatos.ViewModels;
using System.Collections.Generic;
using System.Threading.Tasks;
using api = Aprovatos.Api.Service;

namespace Aprovatos.Service
{
    public class CareerMapService
    {
        public api.CareerMapService _apiService { get; set; }

        public CareerMapService()
        {
            _apiService = new api.CareerMapService();
        }

        public async Task<List<CareerMapVM>> GetCareerMapList()
        {
            var data = await _apiService.LoadDataFromApi();
            var ret = new List<CareerMapVM>();

            foreach (var item in data) {
                CareerMapVM career = new CareerMapVM()
                {
                    CareerMapId = item.CareerMapId,
                    CareerMapName = item.CareerMapName
                };

                ret.Add(career);
            }

            return ret;
        }
    }
}

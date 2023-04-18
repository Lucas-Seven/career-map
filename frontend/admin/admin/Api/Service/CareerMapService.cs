using admin.Api.Model.Response;
using Newtonsoft.Json;
using System;
using System.Collections.Generic;
using System.Threading.Tasks;

namespace admin.Api.Service
{
    public class CareerMapService : BaseService
    {
        private List<CareerMapResponse> DataList { get; set; }
        public CareerMapService() 
        {
            endpoint = "careerMaps";
            DataList = new List<CareerMapResponse>();
        }

        public async Task<List<CareerMapResponse>> LoadDataFromApi()
        {
            try
            {
                string url = baseUrl + endpoint;
                httpClient.BaseAddress = new Uri(url);
                var json = await httpClient.GetStringAsync("");
                //var json = await httpClient.GetStringAsync(url);
                var dados = JsonConvert.DeserializeObject<List<CareerMapResponse>>(json);

                DataList.AddRange(dados);

                return DataList;
            }
            catch (Exception)
            {
                //throw;
            }

            return DataList;
        }
    }
}

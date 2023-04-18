using admin.Api.Model.Response;
using Newtonsoft.Json;
using System;
using System.Threading.Tasks;

namespace admin.Api.Service
{
    public class CareerMapCompanyPositionsService : BaseService
    {
        private CompanyPositionListResponse Data { get; set; }
        public CareerMapCompanyPositionsService(CareerMapResponse career) 
        {
            endpoint = $"careerMaps/{career.CareerMapId}/companyPositions";
            Data = new CompanyPositionListResponse();
        }

        public async Task<CompanyPositionListResponse> LoadDataFromApi()
        {
            try
            {
                string url = baseUrl + endpoint;
                httpClient.BaseAddress = new Uri(url);
                var json = await httpClient.GetStringAsync("");

                var dados = JsonConvert.DeserializeObject<CompanyPositionListResponse>(json);

                Data = dados;
            }
            catch (Exception)
            {
                //throw;
            }

            return Data;
        }
    }
}

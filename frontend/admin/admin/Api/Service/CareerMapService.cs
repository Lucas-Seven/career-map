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

        public async Task<List<CareerMapResponse>> GetAllCareers()
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

        public async Task<CompanyPositionListResponse> GetCompanyPositionsByCareerMapId(int careerMapId)
        {
            try
            {
                var endpoint = $"careerMaps/{careerMapId}/companyPositions";

                string url = baseUrl + endpoint;
                httpClient.BaseAddress = new Uri(url);
                var json = await httpClient.GetStringAsync("");
                //var json = await httpClient.GetStringAsync(url);
                var dados = JsonConvert.DeserializeObject<CompanyPositionListResponse>(json);

                return dados;
            }
            catch (Exception)
            {
                //throw;
            }

            return new CompanyPositionListResponse();
        }

        public async Task<RequirementListResponse> GetRequirimentsByCompanyPositionId(int careerMapId, int companyPositionId)
        {
            try
            {
                var endpoint = $"careerMaps/{careerMapId}/companyPositions/{companyPositionId}/requirements";

                string url = baseUrl + endpoint;
                httpClient.BaseAddress = new Uri(url);
                var json = await httpClient.GetStringAsync("");
                //var json = await httpClient.GetStringAsync(url);
                var dados = JsonConvert.DeserializeObject<RequirementListResponse>(json);

                return dados;
            }
            catch (Exception)
            {
                //throw;
            }

            return new RequirementListResponse();
        }

        public async Task<bool> Insert(CareerMapResponse careerMap)
        {
            try
            {
                endpoint = "careerMaps/insert";
                string url = baseUrl + endpoint;
                httpClient.BaseAddress = new Uri(url);

                var content = new StringContent(JsonConvert.SerializeObject(careerMap),
                                                 System.Text.Encoding.UTF8,
                                                 "application/json");

                var response = await httpClient.PostAsync("", content);

                var responseContent = await response.Content.ReadAsStringAsync();

                Console.WriteLine(responseContent);
                return true;
            }
            catch (Exception)
            {
                //throw;
            }

            return false;
        }
    }
}

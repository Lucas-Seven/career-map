using admin.Api.Model.Response;
using Newtonsoft.Json;
using System;
using System.Collections.Generic;
using System.Threading.Tasks;

namespace admin.Api.Service
{
    public class CompanyPositionService : BaseService
    {
        private CompanyPositionListResponse DataList {get; set; }

        public CompanyPositionService() 
        {
            endpoint = $"companyPositions";
            DataList = new CompanyPositionListResponse();
        }

        public async Task<CompanyPositionListResponse> GetPositionsByCareerMap(int careerMapId)
        {
            endpoint = $"careerMaps/{careerMapId}/companyPositions";
            try
            {
                string url = baseUrl + endpoint;
                httpClient.BaseAddress = new Uri(url);
                var json = await httpClient.GetStringAsync("");

                var dados = JsonConvert.DeserializeObject<CompanyPositionListResponse>(json);

                DataList = dados;
            }
            catch (Exception)
            {
                //throw;
            }

            return DataList;
        }

        public async Task<List<CompanyPositionInfo>> GetAllPositions()
        {
            List<CompanyPositionInfo> dados = new List<CompanyPositionInfo>();

            try
            {
                string url = baseUrl + endpoint;
                httpClient.BaseAddress = new Uri(url);
                var json = await httpClient.GetStringAsync("");

                dados = JsonConvert.DeserializeObject<List<CompanyPositionInfo>>(json);
            }
            catch (Exception)
            {
                //throw;
            }

            return dados;
        }
        public async Task<bool> Insert(CompanyPositionInfo companyPosition)
        {
            try
            {
                string url = baseUrl + endpoint;
                httpClient.BaseAddress = new Uri(url);

                var content = new StringContent(JsonConvert.SerializeObject(companyPosition),
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
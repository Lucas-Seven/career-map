using admin.Api.Model.Response;
using Newtonsoft.Json;
using System;
using System.Collections.Generic;
using System.Threading.Tasks;

namespace admin.Api.Service
{
    public class CompanyPositionService : BaseService
    {
        public CompanyPositionService() 
        {
            endpoint = $"companyPositions";
        }

        public async Task<CompanyPositionListResponse> GetPositionsByCareerMap(int careerMapId)
        {;
            endpoint = $"careerMaps/{careerMapId}/companyPositions";
            try
            {
                var http = GetHttpClient();

                string url = baseUrl + endpoint;
                http.BaseAddress = new Uri(url);
                var json = await http.GetStringAsync("");

                var dados = JsonConvert.DeserializeObject<CompanyPositionListResponse>(json);

                return dados;
            }
            catch (Exception)
            {
                //throw;
            }

            return new CompanyPositionListResponse();
        }

        public async Task<List<CompanyPositionInfo>> GetAllPositions()
        {
            List<CompanyPositionInfo> dados = new List<CompanyPositionInfo>();

            try
            {
                string url = baseUrl + endpoint;
                HttpClient.BaseAddress = new Uri(url);
                var json = await HttpClient.GetStringAsync("");

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
                HttpClient.BaseAddress = new Uri(url);

                var content = new StringContent(JsonConvert.SerializeObject(companyPosition),
                                                 System.Text.Encoding.UTF8,
                                                 "application/json");

                var response = await HttpClient.PostAsync("", content);

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
using admin.Api.Model.Response;
using Newtonsoft.Json;
using System;
using System.Collections.Generic;
using System.Text;
using System.Threading.Tasks;
using static Microsoft.EntityFrameworkCore.DbLoggerCategory.Database;

namespace admin.Api.Service
{
    public class CompanyPositionService : BaseService
    {
        private CompanyPositionListResponse DataList {get; set; }
        private readonly HttpClient _httpClient;
        
        //public List<CompanyPosition> DataList { get; set; }
        public CompanyPositionService() 
        {
            endpoint = $"companyPositions";
            DataList = new CompanyPositionListResponse();
            //DataList = new List<CompanyPosition>();          
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
                //DataList.AddRange(dados.CompanyPositions);
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

                //DataList = dados;
                //DataList.AddRange(dados.CompanyPositions);
            }
            catch (Exception)
            {
                //throw;
            }

            return dados;
        }
      
        public async Task<List<CompanyPositionInfo>> PostAllPositions()
        {
            HttpClient client = new HttpClient();

            var payload = new { Name = "John", Age = 30 };
            var json = JsonConvert.SerializeObject(payload);
            var content = new StringContent(json, Encoding.UTF8, "application/json");

            HttpRequestMessage request = new HttpRequestMessage(HttpMethod.Post, "https://localhost:7149/api/careerMaps/insert");
            request.Content = content;

            HttpResponseMessage response = await client.SendAsync(request);

            if (response.IsSuccessStatusCode)
            {
                var responseContent = await response.Content.ReadAsStringAsync();
                List<CompanyPositionInfo> companies = JsonConvert.DeserializeObject<List<CompanyPositionInfo>>(responseContent);
                return companies;
            }
            else
            {
                throw new Exception($"Erro: {response.StatusCode}");
            }
        }
    }
}

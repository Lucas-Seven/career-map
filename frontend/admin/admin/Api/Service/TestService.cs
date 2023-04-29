using admin.Api.Model;
using admin.Api.Model.Response;
using admin.ViewModels;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore.Metadata.Internal;
using Newtonsoft.Json;
using System.Net.Http;

namespace admin.Api.Service
{
    public class TestService : BaseService
    {
        public TestService()
        {
            endpoint = $"tests";
        }

        public async Task<List<TestEntireResponse>> GetAllTestsByRequirementId(int requirimentId)
        {
            endpoint = $"tests/requirements/{requirimentId}";
            List<TestEntireResponse> dados = new List<TestEntireResponse>();

            try
            {
                string url = baseUrl + endpoint;
                HttpClient.BaseAddress = new Uri(url);
                var json = await HttpClient.GetStringAsync("");

                dados = JsonConvert.DeserializeObject<List<TestEntireResponse>>(json);
            }
            catch (Exception)
            {
                //throw;
            }

            return dados;
        }


        public async Task<TestEntireResponse> GetTestId(int testId)
        {
            endpoint = $"tests/{testId}";
            TestEntireResponse dados = new TestEntireResponse();

            try
            {
                string url = baseUrl + endpoint;
                HttpClient.BaseAddress = new Uri(url);
                var json = await HttpClient.GetStringAsync("");

                dados = JsonConvert.DeserializeObject<TestEntireResponse>(json);
            }
            catch (Exception)
            {
                //throw;
            }

            return dados;
        }

        public async Task<bool> Insert(MTest test)
        {
            endpoint = "tests/insert";

            try
            {
                string url = baseUrl + endpoint;
                HttpClient.BaseAddress = new Uri(url);

                var content = new StringContent(JsonConvert.SerializeObject(test),
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

        public Dictionary<int, RequirementInfo> LoadDataMemory()
        {
            var careers = new Dictionary<int, RequirementInfo>();

            for (int i = 1; i <= 5; i++)
            {
                careers.Add(i, new RequirementInfo()
                {
                    RequirementId = i,
                    RequirementName = $"Req {i}"
                });
            };
            return careers;
        }
    }
}

using admin.Api.Model.Response;
using admin.ViewModels;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore.Metadata.Internal;
using Newtonsoft.Json;
using System.Net.Http;

namespace admin.Api.Service
{
    public class RequirementService : BaseService
    {
        private RequirementListResponse DataList { get; set; }

        public RequirementService()
        {
            endpoint = $"requirements";
            DataList = new RequirementListResponse();
        }


        public async Task<List<RequirementInfo>> GetAllRequirements()
        {
            List<RequirementInfo> dados = new List<RequirementInfo>();

            try
            {
                string url = baseUrl + endpoint;
                HttpClient.BaseAddress = new Uri(url);
                var json = await HttpClient.GetStringAsync("");

                dados = JsonConvert.DeserializeObject<List<RequirementInfo>>(json);
            }
            catch (Exception)
            {
                //throw;
            }

            return dados;
        }

        public async Task<bool> Insert(RequirementInfo requirement)
        {
            try
            {
                string url = baseUrl + endpoint;
                HttpClient.BaseAddress = new Uri(url);

                var content = new StringContent(JsonConvert.SerializeObject(requirement),
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

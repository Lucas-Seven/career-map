using Newtonsoft.Json;
using System;
using System.Collections.Generic;
using System.Net.Http;
using System.Text;
using System.Threading.Tasks;
using System.Net;
using admin.Api.Model.Response;
using admin.Api.Service;

namespace admin.Services
{
    public class RequirementsServicee : BaseService
    {
        //public CompanyPositionRequirements Data { get; set; }
        private RequirementListResponse Data { get; set; }

        public RequirementsServicee()
        {
            endpoint = $"requirements";
            Data = new RequirementListResponse();
            //Data = new CompanyPositionRequirements();
        }
        public RequirementsServicee(int careerMapId, int companyPositionId)
        {
            endpoint = $"careerMaps/{careerMapId}/companyPositions/{companyPositionId}/requirements";
            Data = new RequirementListResponse();
            //Data = new CompanyPositionRequirements();
        }

        public async Task<List<RequirementResponse>> GetAll()
        {
            return null;
        }

        public async Task<RequirementListResponse> LoadDataFromApi()
        {
            try
            {
                string url = baseUrl + endpoint;
                httpClient.BaseAddress = new Uri(url);
                var json = await httpClient.GetStringAsync("");

                var dados = JsonConvert.DeserializeObject<RequirementListResponse>(json);

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

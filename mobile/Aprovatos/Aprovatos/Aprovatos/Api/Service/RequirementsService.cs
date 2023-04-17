using Newtonsoft.Json;
using System;
using System.Collections.Generic;
using System.Net.Http;
using System.Text;
using Xamarin.Forms;
using System.Threading.Tasks;
using System.Net;
using Aprovatos.Api.Model.Response;

namespace Aprovatos.Api.Service
{
    public class RequirementsService : BaseService
    {
        //public CompanyPositionRequirements Data { get; set; }
        private RequirementListResponse Data { get; set; }
        public RequirementsService(int careerMapId, int companyPositionId) 
        {
            endpoint = $"careerMaps/{careerMapId}/companyPositions/{companyPositionId}/requirements";
            Data = new RequirementListResponse();
            //Data = new CompanyPositionRequirements();
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

using Newtonsoft.Json;
using System;
using System.Collections.Generic;
using System.Net.Http;
using System.Text;
using Xamarin.Forms;
using System.Threading.Tasks;
using Aprovatos.Models;
using System.Net;

namespace Aprovatos.Service
{
    public class CompanyPositionRequirementsService : BaseService
    {
        public CompanyPositionRequirements Data { get; set; }
        public CompanyPositionRequirementsService(CompanyPosition companyPosition) 
        {
            endpoint = $"careerMaps/{companyPosition.CareerMap.CareerMapId}/companyPositions/{companyPosition.CompanyPositionId}/requirements";
            Data = new CompanyPositionRequirements();
        }

        public async Task<CompanyPositionRequirements> LoadDataFromApi()
        {
            try
            {
                string url = baseUrl + endpoint;
                httpClient.BaseAddress = new Uri(url);
                var json = await httpClient.GetStringAsync("");

                var dados = JsonConvert.DeserializeObject<CompanyPositionRequirements>(json);

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

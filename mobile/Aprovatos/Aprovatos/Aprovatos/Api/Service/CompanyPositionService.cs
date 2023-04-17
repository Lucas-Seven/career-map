using Aprovatos.Api.Model.Response;
using Newtonsoft.Json;
using System;
using System.Collections.Generic;
using System.Threading.Tasks;

namespace Aprovatos.Api.Service
{
    public class CompanyPositionService : BaseService
    {
        private CompanyPositionListResponse DataList {get; set; }
        //public List<CompanyPosition> DataList { get; set; }
        public CompanyPositionService(int careerMapId) 
        {
            endpoint = $"careerMaps/{careerMapId}/companyPositions";
            DataList = new CompanyPositionListResponse();
            //DataList = new List<CompanyPosition>();
        }

        public async Task<CompanyPositionListResponse> LoadDataFromApi()
        {
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
    }
}

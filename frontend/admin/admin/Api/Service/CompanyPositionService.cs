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
    }
}

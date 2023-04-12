using Newtonsoft.Json;
using System;
using System.Collections.Generic;
using System.Net.Http;
using System.Text;
using Xamarin.Forms;
using System.Threading.Tasks;
using Aprovatos.Models;
using System.Net;
using Aprovatos.ModelsFuturas;

namespace Aprovatos.Service
{
    public class CompanyPositionService : BaseService
    {
        public List<CompanyPosition> DataList { get; set; }
        public CompanyPositionService(int companyId) 
        {
            endpoint = $"careerMaps/{companyId}/companyPositions";
            DataList = new List<CompanyPosition>();
        }

        public async Task<List<CompanyPosition>> LoadDataFromApi()
        {
            try
            {
                string url = baseUrl + endpoint;
                httpClient.BaseAddress = new Uri(url);
                var json = await httpClient.GetStringAsync("");

                var dados = JsonConvert.DeserializeObject<CareerMapCompanyPositions>(json);

                DataList.AddRange(dados.CompanyPositions);
            }
            catch (Exception)
            {
                //throw;
            }

            return DataList;
        }
    }
}

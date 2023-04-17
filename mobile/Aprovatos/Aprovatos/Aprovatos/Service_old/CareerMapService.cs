using Newtonsoft.Json;
using System;
using System.Collections.Generic;
using System.Net.Http;
using System.Text;
using Xamarin.Forms;
using System.Threading.Tasks;
using Aprovatos.Models;

namespace Aprovatos.Service_old
{
    public class CareerMapService : BaseService
    {
        public List<CareerMap> DataList { get; set; }
        public CareerMapService() 
        {
            endpoint = "careerMaps";
            DataList = new List<CareerMap>();
        }

        public async Task<List<CareerMap>> LoadDataFromApi()
        {
            try
            {
                string url = baseUrl + endpoint;
                httpClient.BaseAddress = new Uri(url);
                var json = await httpClient.GetStringAsync("");
                //var json = await httpClient.GetStringAsync(url);
                var dados = JsonConvert.DeserializeObject<List<CareerMap>>(json);

                DataList.AddRange(dados);

                return DataList;
            }
            catch (Exception)
            {
                //throw;
            }

            return DataList;
        }
    }
}

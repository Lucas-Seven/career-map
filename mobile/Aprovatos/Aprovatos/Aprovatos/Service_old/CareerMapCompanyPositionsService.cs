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

namespace Aprovatos.Service_old
{
    public class CareerMapCompanyPositionsService : BaseService
    {
        public CareerMapCompanyPositions Data { get; set; }
        public CareerMapCompanyPositionsService(CareerMap career) 
        {
            endpoint = $"careerMaps/{career.CareerMapId}/companyPositions";
            Data = new CareerMapCompanyPositions();
        }

        public async Task<CareerMapCompanyPositions> LoadDataFromApi()
        {
            try
            {
                string url = baseUrl + endpoint;
                httpClient.BaseAddress = new Uri(url);
                var json = await httpClient.GetStringAsync("");

                var dados = JsonConvert.DeserializeObject<CareerMapCompanyPositions>(json);

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

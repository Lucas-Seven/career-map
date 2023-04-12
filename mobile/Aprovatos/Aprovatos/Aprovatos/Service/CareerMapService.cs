using Newtonsoft.Json;
using System;
using System.Collections.Generic;
using System.Net.Http;
using System.Text;
using Models;
using Xamarin.Forms;
using System.Threading.Tasks;

namespace Aprovatos.Service
{
    public class CareerMapService
    {
        public List<CareerMapVM> Careers { get; set; }
        public CareerMapService() 
        {
            Careers = new List<CareerMapVM>();
        }

        //private async List<CareerMapVM> LoadDataFromMock()
        public List<CareerMapVM> LoadDataFromMock()
        {

            for (int i = 0; i < 10; i++)
            {
                var career = new CareerMapVM()
                {
                    CareerMapId = i,
                    CareerMapName = $"Carreira {i}"
                };

                Careers.Add(career);
            }

            return Careers;
        }

        //private async List<CareerMapVM> LoadDataFromApi()
        public async Task<List<CareerMapVM>> LoadDataFromApi()
        {
            try
            {
                ////https://localhost:7149/api/careerMaps

                //obtendo o json da API em forma de strin
                //string url = "https://10.0.2.2:7149/api/careerMaps";

                string url1 = "http://127.0.0.1:7149/api/careerMaps";
                string url2 = "https://127.0.0.1:7149/api/careerMaps";
                string url3 = "http://10.0.2.2:7149/api/careerMaps";
                string url4 = "https://10.0.2.2:7149/api/careerMaps";





                HttpClientHandler clientHandler = new HttpClientHandler
                {
                    ServerCertificateCustomValidationCallback = (sender, cert, chain, sslPolicyErrors) => { return true; }
                };
                HttpClient client = new HttpClient(clientHandler);


                //client.BaseAddress = new Uri(url);
                var json = await client.GetStringAsync(url4);
                //var json = await client.GetStringAsync(url);

                //desserializando o json para o objeto Endereco

                //var CareerMapVM = new
                //{
                //    CareerMapId = 0,
                //    CareerMapName = ""
                //};


                var dados = JsonConvert.DeserializeObject<List<CareerMapVM>>(json);
                Careers.AddRange(dados);


                //Console.WriteLine(dados);



                //var customer2 = JsonConvert.DeserializeAnonymousType(json, CareerMapVM);
                //Careers.AddRange(null);


                return Careers;
            }
            catch (Exception)
            {
                throw;
            }
        }

        class MyCareerMapVM
        {
            public int CareerMapId { get; set; }
            public string CareerMapName { get; set; }
        }
    }
}

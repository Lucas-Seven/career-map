using Newtonsoft.Json;
using System;
using System.Collections.Generic;
using System.Net.Http;
using System.Text;
using Xamarin.Forms;
using System.Threading.Tasks;
using Aprovatos.Models;

namespace Aprovatos.Service
{
    public class BaseService
    {
        protected string baseUrl = "https://10.0.2.2:7149/api/";
        protected HttpClient httpClient;
        protected string endpoint;
        public BaseService() 
        {
            HttpClientHandler clientHandler = new HttpClientHandler
            {
                ServerCertificateCustomValidationCallback = (sender, cert, chain, sslPolicyErrors) => { return true; }
            };
            httpClient = new HttpClient(clientHandler);
        }
    }
}

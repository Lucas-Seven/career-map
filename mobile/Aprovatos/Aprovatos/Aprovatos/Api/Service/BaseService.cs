using System.Net.Http;

namespace Aprovatos.Api.Service
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

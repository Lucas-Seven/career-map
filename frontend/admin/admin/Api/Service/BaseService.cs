using System.Net.Http;

namespace admin.Api.Service
{
    public class BaseService
    {
        protected string baseUrl = "https://localhost:7149/api/";
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

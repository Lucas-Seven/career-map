using System.Net.Http;

namespace admin.Api.Service
{
    public class BaseService
    {
        protected string baseUrl = "https://localhost:7149/api/";
        protected HttpClient _httpClient;

        protected HttpClient HttpClient { 
            get { return _httpClient; }
            private set { _httpClient = value; }
        }

        protected string endpoint;
        public BaseService() 
        {
            HttpClient = GetHttpClient();
        }

        protected HttpClient GetHttpClient()
        {
            HttpClientHandler clientHandler = new HttpClientHandler
            {
                ServerCertificateCustomValidationCallback = (sender, cert, chain, sslPolicyErrors) => { return true; }
            };

            HttpClient _httpClient = new HttpClient(clientHandler);

            return _httpClient;
        }
    }
}

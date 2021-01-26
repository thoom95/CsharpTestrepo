using System.Net.Http;
using System.Net.Http.Headers;

namespace IntegrationTestTool
{
    public sealed class HTTPClientSetup
    {
        //Singleton Pattern
        public static HTTPClientSetup Instance { get; } = new HTTPClientSetup();
        public HttpClient ApiClient { get; set; }

        private HTTPClientSetup() 
        {
            ApiClient = new HttpClient();
        }

        public void setHeaders()
        {
            ApiClient.DefaultRequestHeaders.Accept.Clear();
            ApiClient.DefaultRequestHeaders.Accept.Add(new MediaTypeWithQualityHeaderValue("application/json"));
        }
    }
}

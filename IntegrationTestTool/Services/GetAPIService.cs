using IntegrationTestTool.Models;
using IntegrationTestTool.Utils;
using System;
using System.Net.Http;
using System.Net.Http.Headers;
using System.Text;
using System.Threading.Tasks;

namespace IntegrationTestTool.Services
{
    public class GetAPIService : IGetAPIService
    {
        readonly IJsonConvertService JsonConvertService = new JsonConvertService();
        public async Task<object> GetGeneric(object obj)
        {
            string url;
            if (obj.GetType() == typeof(Label))
            {
                url = APIConstants.GETLABELS;
            }
            else
            {
                url = APIConstants.GETPRINTERS;
            }
            HTTPClientSetup.ApiClient.DefaultRequestHeaders.Authorization =
                new AuthenticationHeaderValue("bearer", RequestJSONBuilderService.KatalonRequest.BearerToken);
            using (HttpResponseMessage response = await HTTPClientSetup.ApiClient.GetAsync(url))
            {
                if (response.IsSuccessStatusCode)
                {
                    if (obj.GetType() == typeof(Label))
                    {
                        Label label = await response.Content.ReadAsAsync<Label>();
                        return label;
                    }
                    else
                    {
                        Printer printer = await response.Content.ReadAsAsync<Printer>();
                        return printer;
                    }
                }
                else
                {
                    throw new HttpRequestException();
                }
            }
        }

        public async Task<string> GetAuthToken(string username, string password)
        {
            AuthRequest requestBody = new AuthRequest
            {
                Username = username,
                Password = password
            };
            var request = new HttpRequestMessage
            {
                Method = HttpMethod.Post,
                RequestUri = new Uri(APIConstants.AUTHURL),
                Content = new StringContent(JsonConvertService.SerializeToJson(requestBody), Encoding.UTF8, "application/json")
            };

            HTTPClientSetup.ApiClient.DefaultRequestHeaders.Clear();
            using (HttpResponseMessage response = await HTTPClientSetup.ApiClient.SendAsync(request))
            {
                if (response.IsSuccessStatusCode)
                {
                    BearerToken token = Newtonsoft.Json.JsonConvert.DeserializeObject<BearerToken>(response.Content.ReadAsStringAsync().Result);
                    return token.Token;
                }
                else
                {
                    throw new HttpRequestException();
                }
            }
        }
    }
}

using IntegrationTestTool.Models;
using IntegrationTestTool.Models;
using IntegrationTestTool.Services;
using IntegrationTestTool.Utils;
using System;
using System.Collections.Generic;
using System.Net.Http;
using System.Net.Http.Headers;
using System.Text;
using System.Threading.Tasks;

namespace IntegrationTestTool.Services
{
    public class GetAPIService
    {
        JsonConvertService JsonConvertService = new JsonConvertService();
        public async Task<object> GetLabels(object obj)
        {
            string url;
            if(obj.GetType() == typeof(Label))
            {
                Console.WriteLine("this is label");
                url = APIConstants.GETLABELS;

            }
            else
            {
                Console.WriteLine("is printer :(");
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


                        Console.WriteLine(response.Content);
                        Label label = await response.Content.ReadAsAsync<Label>();
                        //Console.WriteLine("ID = " + label.Total);
                        return label;
                    }
                    else
                    {
                        //return printer
                        return null;
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
                    Console.WriteLine(response.Content);
                    return await response.Content.ReadAsStringAsync();
                }
                else
                {
                    throw new HttpRequestException();
                }
            }
        }
    }
}

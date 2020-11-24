using System;
using System.Collections.Generic;
using System.Net.Http;
using System.Text;
using System.Threading.Tasks;

namespace ConsoleApp3.Services
{
    public class GetAPIService
    {
        public async Task<Product> GetData(string url)
        {
            /*            using (var client = new HttpClient())
                        {
                            client.BaseAddress = new Uri("http://localhost:8080/my_app_war/");
                            client.DefaultRequestHeaders.Accept.Clear();
                            client.DefaultRequestHeaders.Accept.Add(new MediaTypeWithQualityHeaderValue("application/json"));
                            //GET Method
            */
            using (HttpResponseMessage response = await HTTPClientSetup.ApiClient.GetAsync(url))
            {
                if (response.IsSuccessStatusCode)
                {
                    Product prod = await response.Content.ReadAsAsync<Product>();
                    Console.WriteLine("ID = " + prod.Name);
                    Console.WriteLine("ID = " + prod);
                    return prod;
                }
                else
                {
                    throw new HttpRequestException();
                }
            }
        }
    }
}

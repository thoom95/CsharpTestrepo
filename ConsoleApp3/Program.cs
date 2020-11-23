using System;
using System.Threading.Tasks;
using System.Net.Http;
using System.Net.Http.Headers;

namespace ConsoleApp3
{
    class Program
    {
        static void Main(string[] args)
        {
            /*            RestGetter.InitClient();
                        Console.WriteLine(BreakfastGetter.LoadBreakfast(3));*/
            GetData().Wait();
        }

        static async Task GetData()
        {
            using (var client = new HttpClient())
            {
                client.BaseAddress = new Uri("http://localhost:8080/my_app_war/");
                client.DefaultRequestHeaders.Accept.Clear();
                client.DefaultRequestHeaders.Accept.Add(new MediaTypeWithQualityHeaderValue("application/json"));
                //GET Method

                HttpResponseMessage response = await client.GetAsync("items/3");
                if (response.IsSuccessStatusCode)
                {
                    Product prod = await response.Content.ReadAsAsync<Product>();
                    Console.WriteLine("ID = " + prod.Title);
                }
                else
                {
                    throw new HttpRequestException();
                }
            }
        }
    }
}

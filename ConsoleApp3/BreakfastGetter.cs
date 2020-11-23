using System;
using System.Collections.Generic;
using System.Net.Http;
using System.Text;
using System.Threading.Tasks;

namespace ConsoleApp3
{
    public class BreakfastGetter
    {
        public static async Task<Product> LoadBreakfast(int number)
        {
            string url = "http://localhost:8080/my_app_war/items/3";
            Console.WriteLine($"URL = { url } ");

            HttpResponseMessage response = await RestGetter.ApiClient.GetAsync(url);
            
                Console.WriteLine("in using ok");

                if (response.IsSuccessStatusCode)
                {
                    Console.WriteLine("status ok");
                    Product product = await response.Content.ReadAsAsync<Product>();

                    return product;
                }
                else
                {
                    Console.WriteLine("status niet ok");
                    throw new Exception(response.ReasonPhrase);
                }
                      
        }
    }
}

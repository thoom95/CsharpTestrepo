using System;
using System.Threading.Tasks;
using System.Net.Http;
using System.Net.Http.Headers;
using ConsoleApp3.Services;

namespace ConsoleApp3
{
    class Program
    {
        static void Main(string[] args)
        {
            HTTPClientSetup.InitClient();
            GetAPIService apiService = new GetAPIService();

            //Product prod2 = apiService.GetData("http://localhost:8080/my_app_war/items/3").GetAwaiter().GetResult();
            Task<Product> task1 = Task.Run(() =>
            {
                return apiService.GetData("http://localhost:8080/my_app_war/items/3");
            });

            Console.WriteLine("test " + task1.Result.Id + " " + task1.Result.Name);
        }




    }
}

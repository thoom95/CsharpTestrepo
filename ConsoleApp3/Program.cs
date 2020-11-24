using System;
using System.Threading.Tasks;
using System.Net.Http;
using System.Net.Http.Headers;
using ConsoleApp3.Services;
using ConsoleApp3.Models;

namespace ConsoleApp3
{
    class Program
    {
        static async Task Main(string[] args)
        {
            HTTPClientSetup.InitClient();
            GetAPIService apiService = new GetAPIService();
            JsonConvertService jsonConverter = new JsonConvertService();

            string url = "https://test-2.ovotrack.io/api/report/swagger/index.html#/Label/Label_GetLabel";
            string url2 = "http://localhost:8080/my_app_war/items/2";
            string url3 = "https://test-2.ovotrack.io/api/report/label";
            Task <Label> task1 = Task.Run(() =>
            {
                return apiService.GetData(url3);
            });

            Label label2 = await task1;
            string convertedLabel = jsonConverter.SerializeToJson(label2);
            Console.WriteLine("Json: "+ convertedLabel);

           
            Console.WriteLine(label2.Total + "echte");
            Console.WriteLine(label2.Results[0].Description);
            Console.WriteLine("test " + task1.Result.Total);
            Console.WriteLine("test " + task1.Result.Results[0].Name);
            Console.WriteLine("test " + task1.Result.Results[5].Name);
            Console.WriteLine("test " + task1.Result.Results[10].Name);
            Console.WriteLine("test " + task1.Result.Results[15].Name);
            Console.WriteLine("test " + task1.Result.Results[0].Description);
            Console.WriteLine("test " + task1.Result.Results[0].IsActive);
            Console.WriteLine("test " + task1.Result.Results[0].ProcedureName);
            Console.WriteLine("test " + task1.Result.Results[0].LabelTypeParameterCode);
        }
    }
}

using System;
using System.Threading.Tasks;
using System.Net.Http;
using System.Net.Http.Headers;
using ConsoleApp3.Services;
using ConsoleApp3.Models;
using ConsoleApp3.Models.KatalonRequestBody;

namespace ConsoleApp3
{
    class Program
    {
        static async Task Main(string[] args)
        {
            HTTPClientSetup.InitClient();
            GetAPIService apiService = new GetAPIService();
            JsonConvertService jsonConverter = new JsonConvertService();
            IOService iOService = new IOService();

            string url = "https://test-2.ovotrack.io/api/report/swagger/index.html#/Label/Label_GetLabel";
            string url2 = "https://test-2.ovotrack.io/api/report/label?take=3&skip=3";
            string url3 = "https://test-2.ovotrack.io/api/report/label";
            Task <Label> task1 = Task.Run(() =>
            {
                return apiService.GetData(url2);
            });

            Label label2 = await task1;
            string convertedLabel = jsonConverter.SerializeToJson(label2);
            Console.WriteLine("Json: "+ convertedLabel);

            string ktln1 = jsonConverter.SerializeToJson(new GETLabelsTestSuite1
                {
                    Skip = 4,
                    Take = 4
                });
            Console.WriteLine(ktln1);
            
            iOService.WriteJsonToFile(ktln1, "GETlabels1");
            Console.WriteLine(label2.Total + "echte");
            Console.WriteLine(label2.Results[0].Description);
            Console.WriteLine("test " + task1.Result.Total);
        }
    }
}

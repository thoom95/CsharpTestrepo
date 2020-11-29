using System;
using System.Threading.Tasks;
using IntegrationTestTool.Services;
using IntegrationTestTool.Models;
using IntegrationTestTool.Models.KatalonRequestBody;
using IntegrationTestTool.Utils;

namespace IntegrationTestTool
{
    public class Program
    {
        static JsonConvertService jsonConverter;
        static IOService iOService;
        static GetAPIService apiService;

        static async Task Main(string[] args)
        {
            InitializeServices();
            RequestJSONBuilderService.KatalonRequest.BearerToken = await apiService.GetAuthToken(APIConstants.AUTHUSER, APIConstants.AUTHPASS);
            Console.WriteLine("auth =  " + RequestJSONBuilderService.KatalonRequest.BearerToken);
            //RequestJSONBuilderService.AddLabelRequest(await apiService.GetLabels(new Label()));
            RequestJSONBuilderService.AddLabelRequest();
            string json = jsonConverter.SerializeToJson(RequestJSONBuilderService.KatalonRequest);
            Console.WriteLine(json);

            //string url = "https://test-2.ovotrack.io/api/report/swagger/index.html#/Label/Label_GetLabel";
            string url2 = "https://test-2.ovotrack.io/api/report/label?take=3&skip=3";
            //string url3 = "https://test-2.ovotrack.io/api/report/label";

            /*            Task <Label> task1 = Task.Run(() =>
                        {
                            return apiService.GetData(url2);
                        });*/
            AuthRequest testlabel = new AuthRequest();
            AuthRequest label2 = (AuthRequest)await apiService.GetLabels(testlabel);
            string convertedLabel = jsonConverter.SerializeToJson(label2);
            Console.WriteLine("Json: "+ convertedLabel);

            string ktln1 = jsonConverter.SerializeToJson(new KtLabel
                {
                    Skip = 4,
                    Take = 4
                });
            Console.WriteLine(ktln1);
            
            iOService.WriteJsonToFile(ktln1, "GETlabels1");
            //Console.WriteLine(label2.Total + "echte");
            //Console.WriteLine(label2.Results[0].Description);
        }

        public static void InitializeServices()
        {
            jsonConverter = new JsonConvertService();
            iOService = new IOService();
            apiService = new GetAPIService();
            HTTPClientSetup.InitClient();
        }
    }
}

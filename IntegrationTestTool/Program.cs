using IntegrationTestTool.Models;
using IntegrationTestTool.Services;
using IntegrationTestTool.Utils;
using System;
using System.Collections.Generic;
using System.Threading.Tasks;

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
            //Get bearer token for API calls
            RequestJSONBuilderService.KatalonRequest.BearerToken = await apiService.GetAuthToken(APIConstants.AUTHUSER, APIConstants.AUTHPASS);

            //Get all labels and printers for later use and store in List
            Label allLabelsResponse = (Label)await apiService.GetGeneric(new Label());
            List<int> labelIds = jsonConverter.ProcessJsonToLabelIds(allLabelsResponse);

            Printer allPrinterResponse = (Printer)await apiService.GetGeneric(new Printer());
            List<string> printerNames = jsonConverter.ProcessJsonToPrinterNames(allPrinterResponse);

            //Build request bodies
            RequestJSONBuilderService.AddLabelRequest(labelIds);
            RequestJSONBuilderService.AddPrinterRequest(printerNames);
            RequestJSONBuilderService.BuildPrintRequest(labelIds, printerNames);

            //Convert request bodies to Json and write to file
            string completeRequestJson = jsonConverter.SerializeToJson(RequestJSONBuilderService.KatalonRequest);
            Console.WriteLine("Json: " + completeRequestJson);

            iOService.WriteJsonToFile(completeRequestJson, "JsonRequest");
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

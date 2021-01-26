using IntegrationTestTool.Models;
using IntegrationTestTool.Services;
using IntegrationTestTool.Utils;
using System;
using System.Collections.Generic;
using System.Net.Http;
using System.Threading.Tasks;

namespace IntegrationTestTool
{
    public class TestTool
    {
        static async Task Main(string[] args)
        {
            IJsonConvertService jsonConverter = new JsonConvertService();
            IIOService iOService = new IOService();
            IGetAPIService apiService = new GetAPIService();
            RequestJSONBuilderService jsonBuilder = new RequestJSONBuilderService();

            HTTPClientSetup httpClient = HTTPClientSetup.Instance;
            httpClient.setHeaders();

            //Get bearer token for API calls
            jsonBuilder.KatalonRequest.BearerToken = await apiService.GetAuthToken(APIConstants.AUTHUSER, APIConstants.AUTHPASS);

            //Get all labels and printers for later use and store in List
            Label allLabelsResponse = (Label)await apiService.GetGeneric(new Label(), jsonBuilder.KatalonRequest.BearerToken);
            List<int> labelIds = jsonConverter.ProcessJsonToLabelIds(allLabelsResponse);

            Printer allPrinterResponse = (Printer)await apiService.GetGeneric(new Printer(), jsonBuilder.KatalonRequest.BearerToken);
            List<string> printerNames = jsonConverter.ProcessJsonToPrinterNames(allPrinterResponse);

            //Build request bodies
            jsonBuilder.AddLabelRequest(labelIds);
            jsonBuilder.AddPrinterRequest(printerNames);
            jsonBuilder.BuildPrintRequest(labelIds, printerNames);

            //Convert request bodies to Json and write to file
            string completeRequestJson = jsonConverter.SerializeToJson(jsonBuilder.KatalonRequest);
            Console.WriteLine("Json: " + completeRequestJson);

            iOService.WriteJsonToFile(completeRequestJson, "JsonRequest");
        }
    }
}

using IntegrationTestTool.Models;
using System.Collections.Generic;

namespace IntegrationTestTool.Services
{
    public class JsonConvertService : IJsonConvertService
    {
        public string SerializeToJson(object obj)
        {
            return Newtonsoft.Json.JsonConvert.SerializeObject(obj, Newtonsoft.Json.Formatting.Indented);
        }

        public List<int> ProcessJsonToLabelIds(Label label)
        {
            List<int> labelIds = new List<int>();
            for (int i = 0; i < 10; i += 2)
            {
                labelIds.Add(label.Results[i].Id);
            }
            return labelIds;
        }

        public List<string> ProcessJsonToPrinterNames(Printer allPrinterResponse)
        {
            List<string> printerNames = new List<string>();
            for (int i = 0; i < 10; i += 2)
            {
                printerNames.Add(allPrinterResponse.Results[i].Name);
            }
            return printerNames;
        }
    }
}

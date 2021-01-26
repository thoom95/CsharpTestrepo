using IntegrationTestTool.Models;
using System.Collections.Generic;

namespace IntegrationTestTool.Services
{
    public interface IJsonConvertService
    {
        List<int> ProcessJsonToLabelIds(Label label);
        List<string> ProcessJsonToPrinterNames(Printer allPrinterResponse);
        string SerializeToJson(object obj);
    }
}
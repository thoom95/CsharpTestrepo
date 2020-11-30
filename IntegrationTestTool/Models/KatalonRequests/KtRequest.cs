using IntegrationTestTool.Models.KatalonRequestBody;
using System.Collections.Generic;

namespace IntegrationTestTool.Models.KatalonRequests
{
    public class KtRequest
    {
        public string BearerToken { get; set; }
        public List<KtLabel> Labels { get; set; }
        public List<KtPrinter> Printers { get; set; }
        public List<KtPrint> Print { get; set; }

    }
}

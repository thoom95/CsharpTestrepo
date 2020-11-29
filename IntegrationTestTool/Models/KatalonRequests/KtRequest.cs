using IntegrationTestTool.Models.KatalonRequestBody;
using System;
using System.Collections.Generic;
using System.Text;

namespace IntegrationTestTool.Models.KatalonRequests
{
    public class KtRequest
    {
        public string BearerToken { get; set; }
        public List<KtLabel> Labels { get; set; }
        public List<KtPrinter> Printers { get; set; }
        
    }
}

using IntegrationTestTool.Models;
using IntegrationTestTool.Models.KatalonRequestBody;
using IntegrationTestTool.Models.KatalonRequests;
using System;
using System.Collections.Generic;
using System.Text;

namespace IntegrationTestTool.Services
{
    public static class RequestJSONBuilderService
    {
        public static KtRequest KatalonRequest { get; set; }

        static RequestJSONBuilderService()
        {
            KatalonRequest = new KtRequest();
        }

        internal static void AddLabelRequest()
        {
            KatalonRequest.Labels = new List<KtLabel>
            {
                new KtLabel { Skip = 0, Take = 0 },
                new KtLabel { Skip = 3, Take = 3 },
                new KtLabel { Skip = 5, Take = 5 }
            };
            foreach (KtLabel lbl in KatalonRequest.Labels)
            {
                Console.WriteLine(lbl.Skip);
            }
        }
    }

}

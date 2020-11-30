﻿using IntegrationTestTool.Models.KatalonRequestBody;
using IntegrationTestTool.Models.KatalonRequests;
using System.Collections.Generic;

namespace IntegrationTestTool.Services
{
    public static class RequestJSONBuilderService
    {
        public static KtRequest KatalonRequest { get; set; }

        static RequestJSONBuilderService()
        {
            KatalonRequest = new KtRequest();
        }

        internal static void AddLabelRequest(List<int> labelIds)
        {
            KatalonRequest.Labels = new List<KtLabel>
            {
                new KtLabel { Skip = 0, Take = 0 },
                new KtLabel { Skip = 3, Take = 3 },
                new KtLabel { Skip = 5, Take = 5 }
            };
        }

        internal static void AddPrinterRequest(List<string> printerNames)
        {
            KatalonRequest.Printers = new List<KtPrinter>
            {
                new KtPrinter { Select = printerNames[0], Skip = 0, Take = 0 },
               new KtPrinter { Select = printerNames[1], Skip = 3, Take = 3 },
               new KtPrinter { Select = printerNames[2], Skip = 5, Take = 5 },
               new KtPrinter { Select = printerNames[3], Skip = 2, Take = 2 },
               new KtPrinter { Select = printerNames[4], Skip = 1, Take = 1 },
            };
        }

        internal static void BuildPrintRequest(List<int> labelIds, List<string> printerNames)
        {
            KatalonRequest.Print = new List<KtPrint>
            {
                new KtPrint
                {
                    LabelId = labelIds[0],
                    QueryParameterValue = 181429,
                    PrinterName = printerNames[0],
                    Landscape = true,
                    Copies = 0
                },
                new KtPrint
                {
                    LabelId = labelIds[1],
                    QueryParameterValue = 181441,
                    PrinterName = printerNames[1],
                    Landscape = false,
                    Copies = 2
                },
                new KtPrint
                {
                    LabelId = labelIds[2],
                    QueryParameterValue = 181430,
                    PrinterName = printerNames[2],
                    Landscape = false,
                    Copies = 0
                },
                new KtPrint
                {
                    LabelId = labelIds[3],
                    QueryParameterValue = 181432,
                    PrinterName = printerNames[3],
                    Landscape = true,
                    Copies = 10
                },
                new KtPrint
                {
                    LabelId = labelIds[4],
                    QueryParameterValue = 181439,
                    PrinterName = printerNames[4],
                    Landscape = false,
                    Copies = 6
                },
            };
        }
    }

}
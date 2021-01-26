namespace IntegrationTestTool.Models.KatalonRequests
{
    public class KtPrint
    {
        public int LabelId { get; set; }
        public int QueryParameterValue { get; set; }
        public string PrinterName { get; set; }
        public bool Landscape { get; set; }
        public int Copies { get; set; }
    }
}

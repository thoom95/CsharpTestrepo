namespace IntegrationTestTool.Services
{
    public class IOService : IIOService
    {
        public void WriteJsonToFile(string stringToWrite, string fileName)
        {
            System.IO.File.WriteAllText(@"C:\Users\Thomas-Laptop\source\repos\IntegrationTestTool\IntegrationTestTool\JSONs\" + fileName, stringToWrite);
        }
    }
}

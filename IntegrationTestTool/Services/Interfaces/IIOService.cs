namespace IntegrationTestTool.Services
{
    public interface IIOService
    {
        void WriteJsonToFile(string stringToWrite, string fileName);
    }
}
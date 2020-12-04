using System.Threading.Tasks;

namespace IntegrationTestTool.Services
{
    public interface IGetAPIService
    {
        Task<string> GetAuthToken(string username, string password);
        Task<object> GetGeneric(object obj);
    }
}
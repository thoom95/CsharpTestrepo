using ConsoleApp3.Models;
using System;
using System.Collections.Generic;
using System.Net.Http;
using System.Net.Http.Headers;
using System.Text;
using System.Threading.Tasks;

namespace ConsoleApp3.Services
{
    public class GetAPIService
    {
        public async Task<Label> GetData(string url)
        {
            /*            using (var client = new HttpClient())
                        {
                            client.BaseAddress = new Uri("http://localhost:8080/my_app_war/");
                            client.DefaultRequestHeaders.Accept.Clear();
                            client.DefaultRequestHeaders.Accept.Add(new MediaTypeWithQualityHeaderValue("application/json"));
                            //GET Method
            */
            HTTPClientSetup.ApiClient.DefaultRequestHeaders.Authorization = 
                new AuthenticationHeaderValue("bearer", "eyJhbGciOiJIUzI1NiIsInR5cCI6IkpXVCJ9.eyJzdWIiOiIxIiwidW5pcXVlX25hbWUiOiJhZG1pbiIsImlhdCI6MTYwNjY2ODAxMywiaHR0cDovL3NjaGVtYXMubWljcm9zb2Z0LmNvbS93cy8yMDA4LzA2L2lkZW50aXR5L2NsYWltcy9yb2xlIjoiQWRtaW5pc3RyYXRvciIsIm5iZiI6MTYwNjY2ODAxMywiZXhwIjoxNjA2ODQwODEzLCJpc3MiOiJPdm90cmFjayIsImF1ZCI6Ik92b3RyYWNrIHVzZXJzIn0.Qhl8wh5t3h0hc2jwIi5io0pKoCbDrCvQ0PQ7b9lQcUc");
            using (HttpResponseMessage response = await HTTPClientSetup.ApiClient.GetAsync(url))
            {
                if (response.IsSuccessStatusCode)
                {
                    Console.WriteLine(response.Content);
                    //Product label = await response.Content.ReadAsAsync<Product>();
                    Label label = await response.Content.ReadAsAsync<Label>();
                    Console.WriteLine("ID = " + label.Total);
                    return label;
                }
                else
                {
                    throw new HttpRequestException();
                }
            }
        }
    }
}

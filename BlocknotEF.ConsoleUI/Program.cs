using BlocknotEF.Data.Entities;
using BlocknotEF.Services.Models;
using Newtonsoft.Json;

namespace BlocknotEF.ConsoleUI
{
    internal class Program
    {
        static async Task Main(string[] args)
        {
            string baseUrl = "http://localhost:5087";

            HttpClient httpClient = new HttpClient();
            httpClient.BaseAddress = new Uri(baseUrl);

            //var response = await httpClient.GetAsync("api/record/get-records");

            //if (response.IsSuccessStatusCode)
            //{
            //    string content = await response.Content.ReadAsStringAsync();
            //    List<RecordModel>? records = JsonConvert.DeserializeObject<List<RecordModel>>(content);

            //    if (records != null && records.Count > 0)
            //    {
            //        foreach (RecordModel record in records)
            //        {
            //            Console.WriteLine($"{record.Id} {record.Name} {record.Surname} {record.PhoneNumber}");
            //        }
            //    }
            //}
        }
    }
}
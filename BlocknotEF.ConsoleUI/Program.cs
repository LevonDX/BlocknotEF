using BlocknotEF.Data.Entities;
using BlocknotEF.Services.Asbtract;
using BlocknotEF.Services.Concrete;

namespace BlocknotEF.ConsoleUI
{
    internal class Program
    {
        static async Task Main(string[] args)
        {
            Record record = new Record()
            {
                Name = "Babken",
                Surname = "Smithyan",
                CreateDate = System.DateTime.Now,
                City = new City()
                {
                    Name = "Moscow",
                    Country = new Country()
                    {
                        Name = "Russia"
                    }
                }
            };

            using IRecordService recordService = new RecordService();

            await recordService.CreateRecordAsync(record);
        }
    }
}

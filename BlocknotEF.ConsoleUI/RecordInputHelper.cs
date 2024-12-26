using BlocknotEF.Data.Entities;
using BlocknotEF.Services.Asbtract;
using BlocknotEF.Services.Concrete;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace BlocknotEF.ConsoleUI
{
    internal class RecordInputHelper
    {
        static IRecordService _recordService = new RecordService();

        public static async Task<Record> InputRecordAsync()
        {
            Record record = new Record();
            Console.Write("Enter name:");
            record.Name = Console.ReadLine();

            Console.Write("Enter surname:");
            record.Surname = Console.ReadLine();

            Console.Write("Enter phone number:");
            record.PhoneNumber = Console.ReadLine();

            record.CreateDate = DateTime.UtcNow;

            string? city;
            bool cityExists;
            do
            {
                Console.Write("Enter city:");
                city = Console.ReadLine();

                cityExists = await _recordService.CityExists(city);

            } while (!cityExists);

            record.City = new City();

            return record;
        }
    }
}

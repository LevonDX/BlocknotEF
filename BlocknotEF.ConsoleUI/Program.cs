using BlocknotEF.Data.Entities;
using BlocknotEF.Services.Asbtract;
using BlocknotEF.Services.Concrete;
using BlocknotEF.Services.Enums;

namespace BlocknotEF.ConsoleUI
{
    internal class Program
    {
        private static void ShowMenuItems()
        {
            foreach (string item in Enum.GetNames<MenuItems>())
            {
                Console.WriteLine(item);
            }
        }

        static async Task Main(string[] args)
        {
            ShowMenuItems();
            using IRecordService _recordService = new RecordService();

            MenuItems choice;
            string? menuItem;
            do
            {
                Console.Write("Choose menu item-> ");
                menuItem = Console.ReadLine();

            } while (!Enum.TryParse<MenuItems>(menuItem, true, out choice));

            switch (choice)
            {
                case MenuItems.Add:
                    Record record = await RecordInputHelper.InputRecordAsync();
                    break;

                case MenuItems.Search:
                    Console.Write("Enter name to search:");
                    string? name = Console.ReadLine();

                    if (string.IsNullOrEmpty(name))
                    {
                        Console.WriteLine("Name is empty");
                        break;
                    }

                    List<Record> foundRecord = await _recordService.SearchRecordsByName(name);

                    foundRecord.ForEach(r => Console.WriteLine(r));

                    break;

                case MenuItems.Show:
                    List<Record> records = await _recordService.GetRecords();
                    records.ForEach(r => Console.WriteLine(r));
                    break;
            }
        }
    }
}
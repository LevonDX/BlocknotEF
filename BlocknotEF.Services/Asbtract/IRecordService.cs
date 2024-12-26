using BlocknotEF.Data.Entities;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace BlocknotEF.Services.Asbtract
{
    public interface IRecordService : IDisposable
    {
        Task<List<Record>> GetRecords();

        Task<Record?> GetRecord(int id);

        Task<Record?> GetRecordByName(string name);

        Task<List<Record>> SearchRecordsByName(string name);

        Task CreateRecordAsync(Record record);

        Task UpdateRecord(Record record);

        Task<bool> CityExists(string? cityName);
    }
}

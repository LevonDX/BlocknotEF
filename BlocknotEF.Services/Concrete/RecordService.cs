using BlocknotEF.Data.Context;
using BlocknotEF.Data.Entities;
using BlocknotEF.Services.Asbtract;
using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace BlocknotEF.Services.Concrete
{
    public class RecordService : IRecordService
    {
        BlocknotDbContext _blocknotDbContext = new BlocknotDbContext();

        public async Task<bool> CityExists(string? cityName)
        {
            if (string.IsNullOrEmpty(cityName))
            {
                return false;
            }

            bool exists = await _blocknotDbContext.Cities
                .AnyAsync(c => c.Name.ToLower() == cityName.ToLower());

            return exists;
        }

        public async Task CreateRecordAsync(Record record)
        {
            await _blocknotDbContext.Records.AddAsync(record);
            await _blocknotDbContext.SaveChangesAsync();
        }

        public void Dispose()
        {
            _blocknotDbContext.Dispose();
        }

        public async Task<Record?> GetRecord(int id)
        {
            Record? record = await _blocknotDbContext.Records.FindAsync(id);

            return record;
        }

        public async Task<Record?> GetRecordByName(string name)
        {
            Record? record = await _blocknotDbContext.Records.FirstOrDefaultAsync(r => r.Name == name);

            return record;
        }

        public async Task<List<Record>> GetRecords()
        {
            var records = await _blocknotDbContext.Records
                .Include(r => r.City)
                    .ThenInclude(c => c.Country)

                .ToListAsync();

            return records;
        }

        public async Task<List<Record>> SearchRecordsByName(string name)
        {
            List<Record> records = await _blocknotDbContext.Records
                .Include(r => r.City)
                .Where(r => r.Name.Contains(name))
                .ToListAsync();

            return records;
        }

        public async Task UpdateRecord(Record record)
        {
            _blocknotDbContext.Update(record);

            await _blocknotDbContext.SaveChangesAsync();
        }
    }
}
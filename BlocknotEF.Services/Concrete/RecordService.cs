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
        BlocknotDbContext _bocknotDbContext = new BlocknotDbContext();

        public async Task CreateRecordAsync(Record record)
        {
            try
            {
                await _bocknotDbContext.Records.AddAsync(record);
                await _bocknotDbContext.SaveChangesAsync();
            }
            catch (Exception ex)
            {
                
            }
        }

        public void Dispose()
        {
            _bocknotDbContext.Dispose();
        }

        public async Task<Record?> GetRecord(int id)
        {
            Record? record = await _bocknotDbContext.Records.FindAsync(id);

            return record;
        }

        public async Task<Record?> GetRecordByName(string name)
        {
            Record? record = await _bocknotDbContext.Records.FirstOrDefaultAsync(r => r.Name == name);

            return record;
        }

        public async Task<List<Record>> GetRecords()
        {
            var records = await _bocknotDbContext.Records.ToListAsync();

            return records;
        }

        public async Task UpdateRecord(Record record)
        {
            _bocknotDbContext.Update(record);

            await _bocknotDbContext.SaveChangesAsync();
        }
    }
}

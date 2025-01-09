using BlocknotEF.Data.Context;
using BlocknotEF.Data.Entities;
using BlocknotEF.Services.Abstract;
using BlocknotEF.Services.Models;
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
        BlocknotDbContext _dbContext = new BlocknotDbContext();

        public async Task AddRecord(RecordModel record)
        {
            Record record1 = new Record
            {
                Name = record.Name,
                Surname = record.Surname,
                PhoneNumber = record.PhoneNumber
            };

            await _dbContext.Records.AddAsync(record1);
            await _dbContext.SaveChangesAsync();
        }

        public async Task<List<RecordModel>> GetRecords()
        {
            List<Record> records = await _dbContext.Records.ToListAsync();

            List<RecordModel> model = new List<RecordModel>();

            foreach (Record record in records)
            {
                model.Add(new RecordModel
                {
                    Id = record.Id,
                    Name = record.Name,
                    Surname = record.Surname,
                    PhoneNumber = record.PhoneNumber
                });
            }

            return model;
        }
    }
}
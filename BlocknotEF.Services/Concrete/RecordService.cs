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

        public async Task AddRecordAsync(RecordModel record)
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

        public async Task<RecordModel?> GetRecordAsync(int id)
        {
            Record? record = await _dbContext.Records.FindAsync(id);

            if (record == null)
            {
                return null;
            }

            return new RecordModel
            {
                Id = record.Id,
                Name = record.Name,
                Surname = record.Surname,
                PhoneNumber = record.PhoneNumber
            };
        }

        public async Task<List<RecordModel>> GetRecordsAsync()
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

        public async Task UpdateRecordAsync(RecordModel record)
        {
            Record? record1 = await _dbContext.Records.FindAsync(record.Id);

            record1.Name = record.Name;
            record1.Surname = record.Surname;
            record1.PhoneNumber = record.PhoneNumber;

            await _dbContext.SaveChangesAsync();
        }
    }
}
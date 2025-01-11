using BlocknotEF.Data.Entities;
using BlocknotEF.Services.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace BlocknotEF.Services.Abstract
{
    public interface IRecordService
    {
        Task AddRecordAsync(RecordModel record);
        Task UpdateRecordAsync(RecordModel record);
        Task<RecordModel?> GetRecordAsync(int id);
        Task<List<RecordModel>> GetRecordsAsync();
    }
}

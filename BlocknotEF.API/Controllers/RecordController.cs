using BlocknotEF.Services.Abstract;
using BlocknotEF.Services.Models;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;

namespace BlocknotEF.API.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class RecordController : ControllerBase
    {
        private readonly IRecordService _recordService;

        public RecordController(IRecordService recordService)
        {
            _recordService = recordService;
        }

        [HttpGet]
        [Route("get-records")]
        public async Task<IActionResult> GetRecords()
        {
            List<RecordModel> records = await _recordService.GetRecordsAsync();

            return Ok(records); // json
        }

        /// <summary>
        /// 
        /// </summary>
        /// <param name="record"></param>
        /// <response code="400">If the patient is not found or input is invalid.</response>
        /// <returns></returns>
        [HttpPost]
        [Route("add-record")]
        public async Task<IActionResult> AddRecord([FromBody] RecordModel record)
        {
            try
            {
                if (ModelState.IsValid)
                {
                    await _recordService.AddRecordAsync(record);
                }
                else
                {
                    return BadRequest("invalid values for record model object");
                }
            }
            catch
            {
                return StatusCode(StatusCodes.Status500InternalServerError, "error while adding record");
            }

            return Ok(record.Id);
        }
    }
}
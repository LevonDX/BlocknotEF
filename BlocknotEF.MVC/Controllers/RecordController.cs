using BlocknotEF.Data.Entities;
using BlocknotEF.Services.Abstract;
using BlocknotEF.Services.Models;
using Microsoft.AspNetCore.Mvc;

namespace BlocknotEF.MVC.Controllers
{
    public class RecordController : Controller
    {
        IRecordService _recordService; // dependency injection

        public RecordController(IRecordService recordService)
        {
            _recordService = recordService;
        }

        [HttpGet]
        public async Task<IActionResult> List() 
        {
            List<RecordModel> records = await _recordService.GetRecordsAsync();

            return View(records);

            #region ViewData, ViewBag, TempData, Model
            // 1. ViewData
            // 2. ViewBag
            // 3. TempData
            // 4. Model (strongly typed view)

            // ViewData["Records"] = records;

            // ViewBag.Records = records;

            // TempData["Records"] = records; 
            #endregion
        }

        [HttpGet]
        public async Task<IActionResult> Edit(int id)
        {
            RecordModel? record = await _recordService.GetRecordAsync(id);

            if (record == null)
            {
                return BadRequest("Incorrect ID");
            }

            return View(record);
        }

        [HttpPost]
        public async Task<IActionResult> Edit(RecordModel record)
        {
            await _recordService.UpdateRecordAsync(record);

            return RedirectToAction("List");
        }
    }
}
using Microsoft.AspNetCore.Mvc;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using SalesWebMvc.Services;

namespace SalesWebMvc.Controllers
{
    public class SalesRecordsController : Controller
    {
        private readonly SalesRecordService _salesRecordservice;

        public SalesRecordsController(SalesRecordService salesRecordservice)
        {
            _salesRecordservice = salesRecordservice;
        }

        public IActionResult Index()
        {
            return View();
        }
        public async Task<IActionResult> SimpleSearch(DateTime? minDate, DateTime? maxDate)
        {
            if (!minDate.HasValue) 
            {
                minDate = new DateTime(DateTime.Now.Year, 1, 1);
            }
            if (!maxDate.HasValue)
            {
                maxDate =  DateTime.Now;
            }
            ViewData["minDate"] = minDate.Value.ToString("yyyy-MM-dd");
            ViewData["maxDate"] = minDate.Value.ToString("yyyy-MM-dd");
            var result = await _salesRecordservice.FindByDateAsync(minDate, maxDate);
            return View(result);
        }
        public async Task<IActionResult> GroupingSearch(DateTime? minDate, DateTime? maxDate)
        {
            if (!minDate.HasValue)
            {
                minDate = new DateTime(DateTime.Now.Year, 1, 1);
            }
            if (!maxDate.HasValue)
            {
                maxDate = DateTime.Now;
            }
            ViewData["minDate"] = minDate.Value.ToString("yyyy-MM-dd");
            ViewData["maxDate"] = minDate.Value.ToString("yyyy-MM-dd");
            var result = await _salesRecordservice.FindByDateGroupingAsync(minDate, maxDate);
            return View(result);
        }
    }
}

using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;

namespace TestCalendar.Controllers
{
    public class CalendarController : Controller
    {
        public IActionResult Index(int? month, int? year)
        {
            var calendarMonth = month ?? DateTime.Now.Month;
            var calendarYear = year ?? DateTime.Now.Year;

            return View();
        }
    }
}

using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using TestCalendar.Services;
using TestCalendar.Repositories;
using TestCalendar.Models;

namespace TestCalendar.Controllers
{
    public class CalendarController : Controller
    {
        private CalendarService _calendarService;
        public CalendarController(CalendarService calendarService)
        {
            _calendarService = calendarService;
        }
        public IActionResult Index(int? month, int? year)
        {
            var calendarMonth = month ?? DateTime.Now.Month;
            var calendarYear = year ?? DateTime.Now.Year;
            return View(_calendarService.GetCalendarItems(calendarMonth, calendarYear));
        }
    }
}

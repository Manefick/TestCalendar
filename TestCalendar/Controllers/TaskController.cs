using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using TestCalendar.Models;
using TestCalendar.Repositories;

namespace TestCalendar.Controllers
{
    public class TaskController : Controller
    {
        private readonly ICalendarTaskRepository _calendarTaskRepository;

        public TaskController(ICalendarTaskRepository calendarTaskRepository)
        {
            _calendarTaskRepository = calendarTaskRepository;
        }

        public IActionResult Index(int year, int month, int day)
        {
            return View(new TaskView {CalendarTasks= _calendarTaskRepository.GetTasksByDate(year, month, day),
                Date=new DateTime(year,month,day) });
        }

        [HttpPost]
        public IActionResult AddTask(TaskView task)
        {
            DateTime newDate = new DateTime(task.Date.Year, task.Date.Month, task.Date.Day, task.Time.Hour, task.Time.Minute, 0);
            _calendarTaskRepository.AddTask(new CalendarTask { Description = task.Description, Date = newDate });
            return RedirectToAction("Index", newDate.Date);

        }
        public IActionResult DeleteTask(int id)
        {
            CalendarTask task = _calendarTaskRepository.FindTask(id);
            _calendarTaskRepository.Delete(task);
            return RedirectToAction("Index", task.Date.Date);
        }
    }
}

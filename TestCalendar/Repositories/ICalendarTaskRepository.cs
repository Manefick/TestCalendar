using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using TestCalendar.Models;

namespace TestCalendar.Repositories
{
    public interface ICalendarTaskRepository
    {
        IEnumerable<CalendarTask> Get(DateTime startDate, DateTime endDate);
        IEnumerable<CalendarTask> GetTasksByDate(int year, int month, int day);
        void AddTask(CalendarTask task);
        CalendarTask FindTask(int id);
        void Delete(CalendarTask task);
    }
}

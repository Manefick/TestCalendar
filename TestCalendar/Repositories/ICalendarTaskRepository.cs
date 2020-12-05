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
    }
}

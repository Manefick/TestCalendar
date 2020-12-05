using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using TestCalendar.Models;

namespace TestCalendar.Repositories
{
    public class CalendarTaskRepository : ICalendarTaskRepository
    {
        private readonly ApplicationDbContext _dbContext;

        public CalendarTaskRepository(ApplicationDbContext dbContext)
        {
            _dbContext = dbContext;
        }

        public IEnumerable<CalendarTask> Get(DateTime startDate, DateTime endDate)
        {
            return _dbContext.CalendarTask
                .Where(x => x.Date >= startDate && x.Date <= endDate);
        }
    }
}

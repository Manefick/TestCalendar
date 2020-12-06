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

        public IEnumerable<CalendarTask> GetTasksByDate(int year, int month, int day)
        {
            return _dbContext.CalendarTask.Where(x => x.Date.Year == year && x.Date.Month == month && x.Date.Day == day);
        }

        public IEnumerable<CalendarTask> Get(DateTime startDate, DateTime endDate)
        {
            return _dbContext.CalendarTask
                .Where(x => x.Date >= startDate && x.Date <= endDate);
        }

        public void AddTask(CalendarTask task)
        {
            if (task != null)
            {
                _dbContext.Add(task);
            }
            _dbContext.SaveChanges();
        }

        public CalendarTask FindTask(int id)
        {
            return _dbContext.CalendarTask.FirstOrDefault(x => x.Id == id);
        }

        public void Delete(CalendarTask task)
        {
            _dbContext.Remove(task);
            _dbContext.SaveChanges();
        }
    }
}

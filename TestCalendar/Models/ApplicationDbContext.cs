using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace TestCalendar.Models
{
    public class ApplicationDbContext:DbContext
    {
        public DbSet<CalendarTask> CalendarTask { get; set; }
    }
}

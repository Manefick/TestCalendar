using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace TestCalendar.Models
{
    public class CalendarModel
    {
        public int Month { get; set; }
        public int Year { get; set; }
        public IEnumerable<CalendarItemModel> Items { get; set; }
    }
}

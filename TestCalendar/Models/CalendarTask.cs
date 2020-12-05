using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace TestCalendar.Models
{
    public class CalendarTask
    {
        public int Id { get; set; }
        public string Description { get; set; }
        public DateTime Date { get; set; }
    }
}

using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using System.ComponentModel.DataAnnotations;

namespace TestCalendar.Models
{
    public class TaskView
    {
        [Required(ErrorMessage ="Write")]
        public string Description { get; set; }
        public DateTime Date { get; set; }
        public DateTime Time { get; set; }
        public IEnumerable<CalendarTask> CalendarTasks { get; set; }
    }
}

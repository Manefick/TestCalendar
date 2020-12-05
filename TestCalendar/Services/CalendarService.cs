using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using TestCalendar.Models;
using TestCalendar.Repositories;

namespace TestCalendar.Services
{
	public class CalendarService
	{
		private readonly CalendarTaskRepository _calendarTaskRepository;

		public CalendarService(CalendarTaskRepository calendarTaskRepository)
		{
			_calendarTaskRepository = calendarTaskRepository;
		}

		public CalendarModel GetCalendarItems(int month, int year)
		{
			var dates = GetMonthDates(month, year);
			var calendarTasks = _calendarTaskRepository.Get(dates.First(), dates.Last())
				.GroupBy(x => x.Date.Date)
				.Select(x => new 
				{
					Date = x.Key,
					TaskCount = x.Count()
				});

			return new CalendarModel
			{
				Month = month,
				Year = year,
				Items = dates.Select(x => new CalendarItemModel
				{
					Date = x,
					TaskCount = calendarTasks.Any(y => y.Date == x.Date.Date)
					 ? calendarTasks.First(y => y.Date == x.Date.Date).TaskCount
					 : 0
				})
			};
		}

		private List<DateTime> GetMonthDates(int m, int y)
		{
			var month = new DateTime(y, m, 1);
			List<DateTime> result = new List<DateTime> { };

			var padLeftDays = (int)month.DayOfWeek;
			var currentDay = month;
			if (m != 1)
			{
				var prevMonth = new DateTime(2020, m - 1, 1);
				int countPrevMonth = DateTime.DaysInMonth(y, m - 1);
				var prevDay = prevMonth.AddDays(countPrevMonth - padLeftDays);

				var countMonth = DateTime.DaysInMonth(y, m);
				var newMonth = new DateTime(y, m, countMonth);
				var padRaightDays = 6 - (int)newMonth.DayOfWeek;
				var iterations = DateTime.DaysInMonth(month.Year, month.Month) + padLeftDays + padRaightDays;
				for (int j = 0; j < iterations; j++)
				{
					if (j < padLeftDays)
					{
						result.Add(prevDay);
						prevDay = prevDay.AddDays(1);
					}
					else
					{
						result.Add(currentDay);
						currentDay = currentDay.AddDays(1);
					}
				}
			}
			else
			{
				var prevMonth = new DateTime(y - 1, 12, 1);
				int countPrevMonth = DateTime.DaysInMonth(y - 1, 12);
				var prevDay = prevMonth.AddDays(countPrevMonth - padLeftDays);

				var countMonth = DateTime.DaysInMonth(y, m);
				var newMonth = new DateTime(y, m, countMonth);
				var padRaightDays = 6 - (int)newMonth.DayOfWeek;
				var iterations = DateTime.DaysInMonth(month.Year, month.Month) + padLeftDays + padRaightDays;
				for (int j = 0; j < iterations; j++)
				{
					if (j < padLeftDays)
					{
						result.Add(prevDay);
						prevDay = prevDay.AddDays(1);
					}
					else
					{
						result.Add(currentDay);
						currentDay = currentDay.AddDays(1);
					}
				}
			}

			return result;
		}
	}
}

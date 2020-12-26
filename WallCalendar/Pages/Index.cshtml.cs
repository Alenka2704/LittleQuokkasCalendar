using System;
using System.Collections.Generic;
using System.Linq;

using Microsoft.AspNetCore.Mvc.RazorPages;
using Microsoft.Extensions.Logging;

namespace WallCalendar.Pages
{
	public class IndexModel : PageModel
	{
		private readonly ILogger<IndexModel> _logger;
		public List<DayModel[]>[] monthsArrays;
		public string[] images;
		private SpecialDayModel[] specialDays = new SpecialDayModel[] {
			new SpecialDayModel(new DateTime(1990, 4, 27), SpecialDayEnum.Birthday, "Beautiful wife"),
			new SpecialDayModel(new DateTime(1935, 4, 15), SpecialDayEnum.Birthday, "Wife's grandmother"),
			new SpecialDayModel(new DateTime(1971, 5, 30), SpecialDayEnum.Birthday, "Stefan"),
			new SpecialDayModel(new DateTime(1958, 5, 31), SpecialDayEnum.Birthday, "Father-in-law"),
			new SpecialDayModel(new DateTime(1976, 7, 20), SpecialDayEnum.Birthday, "Ines"),
			new SpecialDayModel(new DateTime(1958, 7, 23), SpecialDayEnum.Birthday, "Mother-in-law"),
			new SpecialDayModel(new DateTime(1950, 7, 27), SpecialDayEnum.Birthday, "Vater"),
			new SpecialDayModel(new DateTime(2010, 8, 5), SpecialDayEnum.Birthday, "Luise"),
			new SpecialDayModel(new DateTime(1954, 8, 6), SpecialDayEnum.Birthday, "Mutter"),
			new SpecialDayModel(new DateTime(1979, 9, 3), SpecialDayEnum.Birthday, "Andrea"),
			new SpecialDayModel(new DateTime(1975, 9, 15), SpecialDayEnum.Birthday, "Enrico"),
			new SpecialDayModel(new DateTime(2007, 9, 25), SpecialDayEnum.Birthday, "Eva"),
			new SpecialDayModel(new DateTime(1986, 11, 2), SpecialDayEnum.Birthday, "Perfect husband"),
			new SpecialDayModel(new DateTime(1991, 12, 13), SpecialDayEnum.Birthday, "Sister-in-law"),
			new SpecialDayModel(new DateTime(1975, 4, 18), SpecialDayEnum.Relationships, "Eltern"),
			new SpecialDayModel(new DateTime(2018, 6, 23), SpecialDayEnum.Relationships, "2 years"),
			new SpecialDayModel(new DateTime(1986, 6, 25), SpecialDayEnum.Relationships, "Parents-in-law"),
			new SpecialDayModel(new DateTime(2018, 11, 9), SpecialDayEnum.Relationships, "Ines and Stefan"),
			new SpecialDayModel(new DateTime(1990, 1, 1), SpecialDayEnum.PublicHoliday, "New Year, CZ"),
			new SpecialDayModel(new DateTime(1990, 1, 6), SpecialDayEnum.PublicHoliday, "Heilige Drei Könige"),
			new SpecialDayModel(new DateTime(1990, 4, 2), SpecialDayEnum.PublicHoliday, "Karfreitag, CZ"),
			new SpecialDayModel(new DateTime(1990, 4, 5), SpecialDayEnum.PublicHoliday, "Ostermontag, CZ"),
			new SpecialDayModel(new DateTime(1990, 5, 1), SpecialDayEnum.PublicHoliday, "Tag der Arbeit, CZ"),
			new SpecialDayModel(new DateTime(1990, 5, 13), SpecialDayEnum.PublicHoliday, "Christi Himmelfahrt"),
			new SpecialDayModel(new DateTime(1990, 5, 24), SpecialDayEnum.PublicHoliday, "Pfingstmontag"),
			new SpecialDayModel(new DateTime(1990, 10, 3), SpecialDayEnum.PublicHoliday, "Tag der Deutschen Einheit"),
			new SpecialDayModel(new DateTime(1990, 10, 31), SpecialDayEnum.PublicHoliday, "Reformationstag"),
			new SpecialDayModel(new DateTime(1990, 12, 24), SpecialDayEnum.PublicHoliday, "Christmas Eve, CZ"),
			new SpecialDayModel(new DateTime(1990, 12, 25), SpecialDayEnum.PublicHoliday, "1. Weihnachtsfeiertag, CZ"),
			new SpecialDayModel(new DateTime(1990, 12, 26), SpecialDayEnum.PublicHoliday, "2. Weihnachtsfeiertag, CZ"),
			new SpecialDayModel(new DateTime(1990, 12, 31), SpecialDayEnum.PublicHoliday, "New Year's Eve"),
			new SpecialDayModel(new DateTime(1990, 1, 7), SpecialDayEnum.Other, "Wife's Christmas"),
			new SpecialDayModel(new DateTime(1990, 1, 14), SpecialDayEnum.Other, "Old New Year"),
			new SpecialDayModel(new DateTime(1990, 2, 14), SpecialDayEnum.Relationships, "Saint Valentine's day"),
			new SpecialDayModel(new DateTime(1990, 3, 8), SpecialDayEnum.Other, "Women's day"),
			new SpecialDayModel(new DateTime(1990, 5, 8), SpecialDayEnum.Other, "CZ"),
			new SpecialDayModel(new DateTime(1990, 7, 5), SpecialDayEnum.Other, "CZ"),
			new SpecialDayModel(new DateTime(1990, 7, 6), SpecialDayEnum.Other, "CZ"),
			new SpecialDayModel(new DateTime(1990, 9, 28), SpecialDayEnum.Other, "CZ"),
			new SpecialDayModel(new DateTime(1990, 10, 28), SpecialDayEnum.Other, "CZ"),
			new SpecialDayModel(new DateTime(1990, 11, 17), SpecialDayEnum.Other, "CZ"),
			new SpecialDayModel(new DateTime(1990, 12, 19), SpecialDayEnum.Other, "Saint Mylolai's day")
		};

		public IndexModel(ILogger<IndexModel> logger) => _logger = logger;

		public void OnGet()
		{
			monthsArrays = new List<DayModel[]>[14];
			int desiredYear = DateTime.Today.Year + 1;
			for (int i = -1; i < 13; i++)//months
			{
				monthsArrays[i + 1] = BuildMonth(i, desiredYear);
			}
		}

		List<DayModel[]> BuildMonth(int month, int year)
		{
			DateTime currentMonth = new DateTime(year, 1, 1).AddMonths(month), thisDay = currentMonth;
			while(thisDay.DayOfWeek!=DayOfWeek.Monday){
				thisDay = thisDay.AddDays(-1);
			}
			List<DayModel[]> thisMonth = new List<DayModel[]>();
			while (thisDay < currentMonth.AddMonths(1))
			{
				DayModel[] thisWeek = new DayModel[7];
				for (int i = 0; i < 7; i++)
				{
					thisWeek[i] = new DayModel(thisDay.Day, specialDays.Where(item => item.Date.Day == thisDay.Day && item.Date.Month == thisDay.Month).ToList(), thisDay.Month == currentMonth.Month);
					thisDay = thisDay.AddDays(1);
				}
				thisMonth.Add(thisWeek);
			}
			return thisMonth;
		}
	}

	public class SpecialDayModel
	{
		public DateTime Date { get; set; }
		public SpecialDayEnum Occasion { get; set; }
		public string Text { get; set; }

		public SpecialDayModel(DateTime _date, SpecialDayEnum _type, string _text)
		{
			Date = _date;
			Occasion = _type;
			if (_type == SpecialDayEnum.Birthday && _date.Year - DateTime.Today.Year % 5 == 0)
			{
				Occasion = SpecialDayEnum.Jubilee;
			}
			if (_type == SpecialDayEnum.Relationships && _date.Year - DateTime.Today.Year % 5 == 0)
			{
				Occasion = SpecialDayEnum.RelationshipsJubilee;
			}
			Text = _text;
		}
	}

	public class DayModel
	{
		public int Date { get; set; }
		public List<SpecialDayModel> SpecialDays { get; set; }
		public bool IsCurrent { get; set; }

		public DayModel(int _date, List<SpecialDayModel> _specialDays, bool _isCurrent)
		{
			Date = _date;
			SpecialDays = _specialDays;
			IsCurrent = _isCurrent;
		}
	}

	public enum SpecialDayEnum
	{
		Birthday = 0,
		PublicHoliday = 1,
		Relationships = 2,
		Other = 3,
		Jubilee = 4,
		RelationshipsJubilee = 5
	}
}

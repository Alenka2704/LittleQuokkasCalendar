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
			//#if LITTLEQUOKKA
			//			new SpecialDayModel(new DateTime(1990, 4, 27), SpecialDayEnum.Birthday, "Beautiful wife"),
			//			new SpecialDayModel(new DateTime(1935, 4, 15), SpecialDayEnum.Birthday, "Wife's grandmother"),
			//			new SpecialDayModel(new DateTime(1958, 5, 31), SpecialDayEnum.Birthday, "Father-in-law"),
			//			new SpecialDayModel(new DateTime(1958, 7, 23), SpecialDayEnum.Birthday, "Mother-in-law"),
			//			new SpecialDayModel(new DateTime(1991, 12, 13), SpecialDayEnum.Birthday, "Sister-in-law"),
			//			new SpecialDayModel(new DateTime(1986, 6, 25), SpecialDayEnum.Relationships, "Parents-in-law"),
			//			new SpecialDayModel(new DateTime(2019, 6, 23), SpecialDayEnum.Relationships, DateTime.Now.Year + 1 - 2019 + " years"),
			//			new SpecialDayModel(new DateTime(1990, 1, 7), SpecialDayEnum.Other, "Wife's Christmas"),
			//			new SpecialDayModel(new DateTime(1990, 1, 14), SpecialDayEnum.Other, "Old New Year"),
			//			new SpecialDayModel(new DateTime(1990, 2, 14), SpecialDayEnum.Other, "Saint Valentine's day"),
			//			new SpecialDayModel(new DateTime(1990, 3, 8), SpecialDayEnum.Other, "Women's day"),
			//			new SpecialDayModel(new DateTime(1990, 4, 14), SpecialDayEnum.Other, "CZ"),
			//			new SpecialDayModel(new DateTime(1990, 5, 8), SpecialDayEnum.Other, "CZ"),
			//			new SpecialDayModel(new DateTime(1990, 7, 4), SpecialDayEnum.Other, "CZ"),
			//			new SpecialDayModel(new DateTime(1990, 7, 5), SpecialDayEnum.Other, "CZ"),
			//			new SpecialDayModel(new DateTime(1990, 7, 6), SpecialDayEnum.Other, "CZ"),
			//			new SpecialDayModel(new DateTime(1990, 9, 28), SpecialDayEnum.Other, "CZ"),
			//			new SpecialDayModel(new DateTime(1990, 10, 28), SpecialDayEnum.Other, "CZ"),
			//			new SpecialDayModel(new DateTime(1990, 11, 17), SpecialDayEnum.Other, "CZ"),
			//			new SpecialDayModel(new DateTime(1990, 12, 19), SpecialDayEnum.Other, "Saint Mykolai's day"),
			//			new SpecialDayModel(new DateTime(1990, 12, 24), SpecialDayEnum.Other, "CZ"),
			//			new SpecialDayModel(new DateTime(1990, 12, 31), SpecialDayEnum.Other, "New Year's Eve"),
			//#endif
			//#if LITTLEQUOKKA

			//			new SpecialDayModel(new DateTime(1971, 5, 30), SpecialDayEnum.Birthday, "Stefan"),
			//			new SpecialDayModel(new DateTime(1976, 7, 20), SpecialDayEnum.Birthday, "Ines"),
			//			new SpecialDayModel(new DateTime(1950, 7, 27), SpecialDayEnum.Birthday, "Vater"),
			//			new SpecialDayModel(new DateTime(2010, 8, 5), SpecialDayEnum.Birthday, "Luise"),
			//			new SpecialDayModel(new DateTime(1954, 8, 6), SpecialDayEnum.Birthday, "Mutter"),
			//			new SpecialDayModel(new DateTime(1979, 9, 3), SpecialDayEnum.Birthday, "Andrea"),
			//			new SpecialDayModel(new DateTime(1975, 9, 15), SpecialDayEnum.Birthday, "Enrico"),
			//			new SpecialDayModel(new DateTime(2007, 9, 25), SpecialDayEnum.Birthday, "Eva"),
			//			new SpecialDayModel(new DateTime(1986, 11, 2), SpecialDayEnum.Birthday,
			//#endif
			//#if LITTLEQUOKKA
			//	"Perfect husband"
			//#endif
			//#if !LITTLEQUOKKA
			//	"Willi"
			//#endif
			//				),
			//#if INES || ELTERN
			//			new SpecialDayModel(new DateTime(1949, 3, 7), SpecialDayEnum.Birthday, "Friedel"),
			//			new SpecialDayModel(new DateTime(1948, 3, 16), SpecialDayEnum.Birthday, "Brigitte"),
			//			new SpecialDayModel(new DateTime(2007, 7, 21), SpecialDayEnum.Birthday, "Jesper"),
			//			new SpecialDayModel(new DateTime(2003, 9, 22), SpecialDayEnum.Birthday, "Lynn"),
			//#endif
			//#if ANDREA || ELTERN
			//			new SpecialDayModel(new DateTime(1953, 2, 24), SpecialDayEnum.Birthday, "Monika"),
			//			new SpecialDayModel(new DateTime(1952, 6, 9), SpecialDayEnum.Birthday, "Dieter"),
			//#endif
			//			new SpecialDayModel(new DateTime(2022, 1, 29), SpecialDayEnum.Relationships, "Andrea und Enrico"),
			//			new SpecialDayModel(new DateTime(1975, 4, 18), SpecialDayEnum.Relationships, "Eltern"),
			//			new SpecialDayModel(new DateTime(2018, 11, 9), SpecialDayEnum.Relationships, "Ines und Stefan"),
			//			new SpecialDayModel(new DateTime(1990, 1, 1), SpecialDayEnum.PublicHoliday,
			//#if LITTLEQUOKKA
			//	"New Year, CZ"
			//#endif
			//#if !LITTLEQUOKKA
			//	"Neujahr"
			//#endif
			//				),
			//#if LITTLEQUOKKA || ELTERN
			//			new SpecialDayModel(new DateTime(1990, 1, 6), SpecialDayEnum.PublicHoliday, "Heilige Drei Könige"),
			//#endif
			//			new SpecialDayModel(new DateTime(1990, 4, 15), SpecialDayEnum.PublicHoliday, "Karfreitag"
			//#if LITTLEQUOKKA
			//	+ ", CZ"
			//#endif
			//				),//floating
			//			new SpecialDayModel(new DateTime(1990, 4, 18), SpecialDayEnum.PublicHoliday, "Ostermontag"
			//#if LITTLEQUOKKA
			//	+ ", CZ"
			//#endif
			//				),//floating
			//			new SpecialDayModel(new DateTime(1990, 5, 1), SpecialDayEnum.PublicHoliday, "Tag der Arbeit"
			//#if LITTLEQUOKKA
			//	+ ", CZ"
			//#endif
			//				),
			//			new SpecialDayModel(new DateTime(1990, 5, 26), SpecialDayEnum.PublicHoliday, "Christi Himmelfahrt"),//floating
			//			new SpecialDayModel(new DateTime(1990, 6, 6), SpecialDayEnum.PublicHoliday, "Pfingstmontag"),//floating
			//#if INES
			//			new SpecialDayModel(new DateTime(1990, 6, 16), SpecialDayEnum.PublicHoliday, "Fronleichnam"),//floating
			//#endif
			//			new SpecialDayModel(new DateTime(1990, 10, 3), SpecialDayEnum.PublicHoliday, "Tag der Deutschen Einheit"),
			//#if !INES
			//			new SpecialDayModel(new DateTime(1990, 10, 31), SpecialDayEnum.PublicHoliday, "Reformationstag"),
			//#endif
			//#if INES
			//			new SpecialDayModel(new DateTime(1990, 11, 1), SpecialDayEnum.PublicHoliday, "Allerheiligen"),
			//#endif
			//#if ANDREA
			//			new SpecialDayModel(new DateTime(1990, 11, 16), SpecialDayEnum.PublicHoliday, "Buß- und Bettag"),//floating
			//#endif
			//			new SpecialDayModel(new DateTime(1990, 12, 25), SpecialDayEnum.PublicHoliday, "1. Weihnachtsfeiertag"
			//#if LITTLEQUOKKA
			//	+ ", CZ"
			//#endif
			//				),
			//			new SpecialDayModel(new DateTime(1990, 12, 26), SpecialDayEnum.PublicHoliday, "2. Weihnachtsfeiertag"
			//#if LITTLEQUOKKA
			//	+ ", CZ"
			//#endif
			//				)
#if ANNA
			new SpecialDayModel(new DateTime(1989, 6, 14), SpecialDayEnum.Birthday, "З ДНЕМ НАРОДЖЕННЯ!"),
			new SpecialDayModel(new DateTime(2010, 01, 06), SpecialDayEnum.Birthday, "Владуся"),

			new SpecialDayModel(new DateTime(1990, 1, 1), SpecialDayEnum.PublicHoliday, "З НОВИМ РОКОМ!, Nový rok"),
			new SpecialDayModel(new DateTime(1990, 4, 15), SpecialDayEnum.PublicHoliday, "Velký pátek"),//floating
			new SpecialDayModel(new DateTime(1990, 4, 18), SpecialDayEnum.PublicHoliday, "Velikonoční pondělí"),//floating
			new SpecialDayModel(new DateTime(1990, 5, 1), SpecialDayEnum.PublicHoliday, "Svátek práce, DE"),
			new SpecialDayModel(new DateTime(1990, 5, 8), SpecialDayEnum.PublicHoliday, "Den vítězství"),
			new SpecialDayModel(new DateTime(1990, 7, 5), SpecialDayEnum.PublicHoliday, "Den Cyrila a Metoděje"),
			new SpecialDayModel(new DateTime(1990, 7, 6), SpecialDayEnum.PublicHoliday, "Den Jana Husa"),
			new SpecialDayModel(new DateTime(1990, 9, 28), SpecialDayEnum.PublicHoliday, "Den české státnosti"),
			new SpecialDayModel(new DateTime(1990, 10, 28), SpecialDayEnum.PublicHoliday, "Den vzniku samostatného československého státu"),
			new SpecialDayModel(new DateTime(1990, 11, 17), SpecialDayEnum.PublicHoliday, "Den boje za svobodu a demokracii"),
			new SpecialDayModel(new DateTime(1990, 12, 24), SpecialDayEnum.PublicHoliday, "Štědrý den"),
			new SpecialDayModel(new DateTime(1990, 12, 25), SpecialDayEnum.PublicHoliday, "1. svátek vánoční, DE"),
			new SpecialDayModel(new DateTime(1990, 12, 26), SpecialDayEnum.PublicHoliday, "2. svátek vánoční, DE"),

			new SpecialDayModel(new DateTime(1990, 1, 7), SpecialDayEnum.Other, "Різдво"),
			new SpecialDayModel(new DateTime(1990, 1, 14), SpecialDayEnum.Other, "Старий Новий рік"),
			new SpecialDayModel(new DateTime(1990, 2, 14), SpecialDayEnum.Other, "День Валентина"),
			new SpecialDayModel(new DateTime(1990, 3, 8), SpecialDayEnum.Other, "З 8-м березня!"),
			new SpecialDayModel(new DateTime(1990, 4, 24), SpecialDayEnum.Other, "Великдень"),//floating
			new SpecialDayModel(new DateTime(1990, 5, 8), SpecialDayEnum.Other, "День матері"),//floating
			new SpecialDayModel(new DateTime(1990, 5, 9), SpecialDayEnum.Other, "День перемоги"),
			new SpecialDayModel(new DateTime(1990, 6, 1), SpecialDayEnum.Other, "День дитини"),
			new SpecialDayModel(new DateTime(1990, 6, 19), SpecialDayEnum.Other, "День батька"),//floating
			new SpecialDayModel(new DateTime(1990, 6, 28), SpecialDayEnum.Other, "День конституції"),
			new SpecialDayModel(new DateTime(1990, 8, 24), SpecialDayEnum.Other, "День незалежності"),
			new SpecialDayModel(new DateTime(1990, 12, 6), SpecialDayEnum.Other, "День Української армії"),
			new SpecialDayModel(new DateTime(1990, 12, 19), SpecialDayEnum.Other, "День Миколая")
#endif
#if VERA
			new SpecialDayModel(new DateTime(2022, 1, 2), SpecialDayEnum.Birthday, "Оля Бикбова"),
			new SpecialDayModel(new DateTime(2022, 1, 11), SpecialDayEnum.Birthday, "Елена Ивановна Комашко"),
			new SpecialDayModel(new DateTime(2022, 1, 11), SpecialDayEnum.Birthday, "Simon Bolívar"),
			new SpecialDayModel(new DateTime(1982, 1, 25), SpecialDayEnum.Birthday, "Happy birthday!"),
			new SpecialDayModel(new DateTime(2014, 3, 17), SpecialDayEnum.Birthday, "Настя"),
			new SpecialDayModel(new DateTime(2022, 4, 10), SpecialDayEnum.Birthday, "Mabel"),
			new SpecialDayModel(new DateTime(2022, 4, 12), SpecialDayEnum.Birthday, "Евгения Калатухина"),
			new SpecialDayModel(new DateTime(1956, 4, 16), SpecialDayEnum.Birthday, "Мама"),
			new SpecialDayModel(new DateTime(1990, 4, 27), SpecialDayEnum.Birthday, "Алёна"),
			new SpecialDayModel(new DateTime(1982, 5, 26), SpecialDayEnum.Birthday, "Аня"),
			new SpecialDayModel(new DateTime(2022, 7, 9), SpecialDayEnum.Birthday, "Kizy Lyrio"),
			new SpecialDayModel(new DateTime(1986, 8, 14), SpecialDayEnum.Birthday, "Борис"),
			new SpecialDayModel(new DateTime(2011, 11, 2), SpecialDayEnum.Birthday, "Тёма"),

			new SpecialDayModel(new DateTime(2022, 1, 1), SpecialDayEnum.PublicHoliday, "New Year's Day"),
			new SpecialDayModel(new DateTime(2022, 3, 17), SpecialDayEnum.PublicHoliday, "St Patrick's day"),
			new SpecialDayModel(new DateTime(2022, 4, 18), SpecialDayEnum.PublicHoliday, "Easter monday"),
			new SpecialDayModel(new DateTime(2022, 5, 2), SpecialDayEnum.PublicHoliday, "May day"),
			new SpecialDayModel(new DateTime(2022, 6, 6), SpecialDayEnum.PublicHoliday, "June bank holiday"),
			new SpecialDayModel(new DateTime(2022, 8, 1), SpecialDayEnum.PublicHoliday, "August bank holiday"),
			new SpecialDayModel(new DateTime(2022, 10, 31), SpecialDayEnum.PublicHoliday, "October bank holiday"),
			new SpecialDayModel(new DateTime(2022, 12, 25), SpecialDayEnum.PublicHoliday, "Christmas day"),
			new SpecialDayModel(new DateTime(2022, 12, 26), SpecialDayEnum.PublicHoliday, "St Stephen's day"),

			new SpecialDayModel(new DateTime(2022, 2, 1), SpecialDayEnum.Other, "Imbolc"),
			new SpecialDayModel(new DateTime(2022, 2, 14), SpecialDayEnum.Other, "St Valentine's day"),
			new SpecialDayModel(new DateTime(2022, 3, 20), SpecialDayEnum.Other, "Ostara"),
			new SpecialDayModel(new DateTime(2022, 4, 15), SpecialDayEnum.Other, "Good Friday"),
			new SpecialDayModel(new DateTime(2022, 4, 17), SpecialDayEnum.Other, "Easter"),
			new SpecialDayModel(new DateTime(2022, 5, 1), SpecialDayEnum.Other, "Beltane"),
			new SpecialDayModel(new DateTime(2022, 6, 21), SpecialDayEnum.Other, "Litha"),
			new SpecialDayModel(new DateTime(2022, 8, 1), SpecialDayEnum.Other, "Lughnasadh"),
			new SpecialDayModel(new DateTime(2022, 9, 22), SpecialDayEnum.Other, "Mabon"),
			new SpecialDayModel(new DateTime(2022, 10, 31), SpecialDayEnum.Other, "Samhain"),
			new SpecialDayModel(new DateTime(2022, 12, 16), SpecialDayEnum.Other, "Christmas Novena"),
			new SpecialDayModel(new DateTime(2022, 12, 21), SpecialDayEnum.Other, "Yule"),
			new SpecialDayModel(new DateTime(2022, 12, 24), SpecialDayEnum.Other, "Christmas eve"),
			new SpecialDayModel(new DateTime(2022, 12, 31), SpecialDayEnum.Other, "New Year's Eve"),

			new SpecialDayModel(new DateTime(2022, 1, 2), SpecialDayEnum.MoonPhase, "New moon"),
			new SpecialDayModel(new DateTime(2022, 1, 9), SpecialDayEnum.MoonPhase, "First quarter"),
			new SpecialDayModel(new DateTime(2022, 1, 17), SpecialDayEnum.MoonPhase, "Full moon"),
			new SpecialDayModel(new DateTime(2022, 1, 25), SpecialDayEnum.MoonPhase, "Last quarter"),
			new SpecialDayModel(new DateTime(2022, 2, 1), SpecialDayEnum.MoonPhase, "New moon"),
			new SpecialDayModel(new DateTime(2022, 2, 8), SpecialDayEnum.MoonPhase, "First quarter"),
			new SpecialDayModel(new DateTime(2022, 2, 16), SpecialDayEnum.MoonPhase, "Full moon"),
			new SpecialDayModel(new DateTime(2022, 2, 23), SpecialDayEnum.MoonPhase, "Last quarter"),
			new SpecialDayModel(new DateTime(2022, 3, 2), SpecialDayEnum.MoonPhase, "New moon"),
			new SpecialDayModel(new DateTime(2022, 3, 10), SpecialDayEnum.MoonPhase, "First quarter"),
			new SpecialDayModel(new DateTime(2022, 3, 18), SpecialDayEnum.MoonPhase, "Full moon"),
			new SpecialDayModel(new DateTime(2022, 3, 25), SpecialDayEnum.MoonPhase, "Last quarter"),
			new SpecialDayModel(new DateTime(2022, 4, 1), SpecialDayEnum.MoonPhase, "New moon"),
			new SpecialDayModel(new DateTime(2022, 4, 9), SpecialDayEnum.MoonPhase, "First quarter"),
			new SpecialDayModel(new DateTime(2022, 4, 23), SpecialDayEnum.MoonPhase, "Last quarter"),
			new SpecialDayModel(new DateTime(2022, 4, 30), SpecialDayEnum.MoonPhase, "New moon"),
			new SpecialDayModel(new DateTime(2022, 5, 9), SpecialDayEnum.MoonPhase, "First quarter"),
			new SpecialDayModel(new DateTime(2022, 5, 16), SpecialDayEnum.MoonPhase, "Full moon"),
			new SpecialDayModel(new DateTime(2022, 5, 22), SpecialDayEnum.MoonPhase, "Last quarter"),
			new SpecialDayModel(new DateTime(2022, 5, 30), SpecialDayEnum.MoonPhase, "New moon"),
			new SpecialDayModel(new DateTime(2022, 6, 7), SpecialDayEnum.MoonPhase, "First quarter"),
			new SpecialDayModel(new DateTime(2022, 6, 14), SpecialDayEnum.MoonPhase, "Full moon"),
			new SpecialDayModel(new DateTime(2022, 6, 21), SpecialDayEnum.MoonPhase, "Last quarter"),
			new SpecialDayModel(new DateTime(2022, 6, 29), SpecialDayEnum.MoonPhase, "New moon"),
			new SpecialDayModel(new DateTime(2022, 7, 7), SpecialDayEnum.MoonPhase, "First quarter"),
			new SpecialDayModel(new DateTime(2022,7, 13), SpecialDayEnum.MoonPhase, "Full moon"),
			new SpecialDayModel(new DateTime(2022, 7, 20), SpecialDayEnum.MoonPhase, "Last quarter"),
			new SpecialDayModel(new DateTime(2022, 7, 28), SpecialDayEnum.MoonPhase, "New moon"),
			new SpecialDayModel(new DateTime(2022, 8, 5), SpecialDayEnum.MoonPhase, "First quarter"),
			new SpecialDayModel(new DateTime(2022, 8, 12), SpecialDayEnum.MoonPhase, "Full moon"),
			new SpecialDayModel(new DateTime(2022, 8, 19), SpecialDayEnum.MoonPhase, "Last quarter"),
			new SpecialDayModel(new DateTime(2022, 8, 27), SpecialDayEnum.MoonPhase, "New moon"),
			new SpecialDayModel(new DateTime(2022, 9, 3), SpecialDayEnum.MoonPhase, "First quarter"),
			new SpecialDayModel(new DateTime(2022, 9, 10), SpecialDayEnum.MoonPhase, "Full moon"),
			new SpecialDayModel(new DateTime(2022, 9, 17), SpecialDayEnum.MoonPhase, "Last quarter"),
			new SpecialDayModel(new DateTime(2022, 9, 25), SpecialDayEnum.MoonPhase, "New moon"),
			new SpecialDayModel(new DateTime(2022, 10, 3), SpecialDayEnum.MoonPhase, "First quarter"),
			new SpecialDayModel(new DateTime(2022, 10, 9), SpecialDayEnum.MoonPhase, "Full moon"),
			new SpecialDayModel(new DateTime(2022, 10, 17), SpecialDayEnum.MoonPhase, "Last quarter"),
			new SpecialDayModel(new DateTime(2022, 10, 25), SpecialDayEnum.MoonPhase, "New moon"),
			new SpecialDayModel(new DateTime(2022, 11, 1), SpecialDayEnum.MoonPhase, "First quarter"),
			new SpecialDayModel(new DateTime(2022, 11, 8), SpecialDayEnum.MoonPhase, "Full moon"),
			new SpecialDayModel(new DateTime(2022, 11, 16), SpecialDayEnum.MoonPhase, "Last quarter"),
			new SpecialDayModel(new DateTime(2022, 11, 23), SpecialDayEnum.MoonPhase, "New moon"),
			new SpecialDayModel(new DateTime(2022, 11, 30), SpecialDayEnum.MoonPhase, "First quarter"),
			new SpecialDayModel(new DateTime(2022, 12, 8), SpecialDayEnum.MoonPhase, "Full moon"),
			new SpecialDayModel(new DateTime(2022, 12, 16), SpecialDayEnum.MoonPhase, "Last quarter"),
			new SpecialDayModel(new DateTime(2022, 12, 23), SpecialDayEnum.MoonPhase, "New moon"),
			new SpecialDayModel(new DateTime(2022, 12, 30), SpecialDayEnum.MoonPhase, "First quarter")
#endif
#if SVETA
			new SpecialDayModel(new DateTime(1981, 1, 20), SpecialDayEnum.Birthday, "Ivan"),
			new SpecialDayModel(new DateTime(1962, 1, 24), SpecialDayEnum.Birthday, "Mom"),
			new SpecialDayModel(new DateTime(1994, 1, 30), SpecialDayEnum.Birthday, "Bogdan"),
			new SpecialDayModel(new DateTime(1999, 1, 30), SpecialDayEnum.Birthday, "Antoniy"),
			new SpecialDayModel(new DateTime(2013, 2, 22), SpecialDayEnum.Birthday, "Danylo"),
			new SpecialDayModel(new DateTime(1960, 3, 2), SpecialDayEnum.Birthday, "Father"),
			new SpecialDayModel(new DateTime(1986, 3, 7), SpecialDayEnum.Birthday, "Larysa"),
			new SpecialDayModel(new DateTime(2021, 3, 20), SpecialDayEnum.Birthday, "Denis"),
			new SpecialDayModel(new DateTime(2019, 3, 27), SpecialDayEnum.Birthday, "Olexandr"),
			new SpecialDayModel(new DateTime(2015, 4, 16), SpecialDayEnum.Birthday, "Timur"),
			new SpecialDayModel(new DateTime(1979, 4, 23), SpecialDayEnum.Birthday, "Ulyana"),
			new SpecialDayModel(new DateTime(2013, 4, 24), SpecialDayEnum.Birthday, "Sofiya"),
			new SpecialDayModel(new DateTime(1990, 4, 27), SpecialDayEnum.Birthday, "Olena"),
			new SpecialDayModel(new DateTime(2009, 5, 9), SpecialDayEnum.Birthday, "Karat"),
			new SpecialDayModel(new DateTime(1990, 5, 10), SpecialDayEnum.Birthday, "Anna"),
			new SpecialDayModel(new DateTime(1985, 5, 13), SpecialDayEnum.Birthday, "Kateryna"),
			new SpecialDayModel(new DateTime(1982, 5, 21), SpecialDayEnum.Birthday, "Dmitriy"),
			new SpecialDayModel(new DateTime(1988, 6, 22), SpecialDayEnum.Birthday, "Iurii"),
			new SpecialDayModel(new DateTime(2012, 6, 7), SpecialDayEnum.Birthday, "Oleksandra"),
			new SpecialDayModel(new DateTime(2012, 8, 1), SpecialDayEnum.Relationships, "Married"),
			new SpecialDayModel(new DateTime(1982, 8, 3), SpecialDayEnum.Birthday, "Nataliia"),
			new SpecialDayModel(new DateTime(1996, 8, 14), SpecialDayEnum.Birthday, "Katya"),
			new SpecialDayModel(new DateTime(1990, 9, 5), SpecialDayEnum.Birthday, "Angelina"),
			new SpecialDayModel(new DateTime(1984, 9, 6), SpecialDayEnum.Birthday, "Denys"),
			new SpecialDayModel(new DateTime(1990, 10, 16), SpecialDayEnum.Birthday, "Olya"),
			new SpecialDayModel(new DateTime(2013, 10, 19), SpecialDayEnum.Birthday, "Emil"),
			new SpecialDayModel(new DateTime(1984, 10, 20), SpecialDayEnum.Birthday, "Dmytro"),
			new SpecialDayModel(new DateTime(2011, 10, 20), SpecialDayEnum.Birthday, "Nikolai"),
			new SpecialDayModel(new DateTime(1989, 11, 12), SpecialDayEnum.Birthday, "Maryanna"),
			new SpecialDayModel(new DateTime(1962, 11, 12), SpecialDayEnum.Birthday, "Father"),
			new SpecialDayModel(new DateTime(2012, 11, 15), SpecialDayEnum.Birthday, "Taras"),
			new SpecialDayModel(new DateTime(1987, 11, 27), SpecialDayEnum.Birthday, "Mariya"),
			new SpecialDayModel(new DateTime(1988, 11, 27), SpecialDayEnum.Birthday, "Lena"),
			new SpecialDayModel(new DateTime(1990, 12, 24), SpecialDayEnum.Birthday, "Sveta"),

			new SpecialDayModel(new DateTime(1990, 12, 24), SpecialDayEnum.PublicHoliday, "European X-mas"),

			new SpecialDayModel(new DateTime(1990, 1, 1), SpecialDayEnum.Other, "New Year"),
			new SpecialDayModel(new DateTime(1990, 1, 7), SpecialDayEnum.Other, "Ukrainian X-mas"),
			new SpecialDayModel(new DateTime(1991, 8, 24), SpecialDayEnum.Other, "Ukrainian independece day"),
#endif
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
			while (thisDay.DayOfWeek != DayOfWeek.Monday)
			{
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
		RelationshipsJubilee = 5,
		MoonPhase = 6
	}
}

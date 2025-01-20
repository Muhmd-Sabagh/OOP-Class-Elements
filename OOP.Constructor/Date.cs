namespace OOP.Constructor
{
	// Represents a date with validation and various initialization options
	public class Date
	{
		private const int MIN_YEAR = 1;
		private const int MAX_YEAR = 9999;
		private const int MIN_MONTH = 1;
		private const int MAX_MONTH = 12;
		private const int DEFAULT_DAY = 1;
		private const int DEFAULT_MONTH = 1;
		private const int DEFAULT_YEAR = 1;

		// Array index represents month number, value represents days in that month
		private static readonly int[] DaysToMonth365 = { 0, 31, 28, 31, 30, 31, 30, 31, 31, 30, 31, 30, 31 };
		private static readonly int[] DaysToMonth366 = { 0, 31, 29, 31, 30, 31, 30, 31, 31, 30, 31, 30, 31 };
													//   0, 1,  2,  3,  4,  5,  6,  7,  8,  9,  10, 11, 12
        private int _day = DEFAULT_DAY;
		private int _month = DEFAULT_MONTH;
		private int _year = DEFAULT_YEAR;

		// A constructor with specific day, month, and year
		public Date(int day, int month, int year)
		{
			if (IsValidDate(day, month, year))
			{
				_day = day;
				_month = month;
				_year = year;
			}
		}

		// A new Constructor with a specific year (day and month default to 1)
		public Date(int year) : this(DEFAULT_DAY, DEFAULT_MONTH, year) { }

		// A new Constructor with specific month and year (day defaults to 1)
		public Date(int month, int year) : this(DEFAULT_DAY, month, year) { }

		// Returns the date in DD/MM/YYYY format
		public string GetDate()
		{
			return $"{_day:D2}/{_month:D2}/{_year:D4}";
		}

		// Returns the date in a specified format
		public string GetDate(string format)
		{
			return format.ToUpper() switch
			{
				"DD/MM/YYYY" => $"{_day:D2}/{_month:D2}/{_year:D4}",
				"MM/DD/YYYY" => $"{_month:D2}/{_day:D2}/{_year:D4}",
				"YYYY/MM/DD" => $"{_year:D4}/{_month:D2}/{_day:D2}",
				_ => GetDate()
			};
		}

		// Validate entered date
		private static bool IsValidDate(int day, int month, int year)
		{
			if (year < MIN_YEAR || year > MAX_YEAR)
				return false;

			if (month < MIN_MONTH || month > MAX_MONTH)
				return false;

			// Checks if the year is a leap year
			static bool IsLeapYear(int year) => year % 4 == 0 && (year % 100 != 0 || year % 400 == 0);

			int[] daysInMonth = IsLeapYear(year) ? DaysToMonth366 : DaysToMonth365;
			return day >= 1 && day <= daysInMonth[month];
		}
	}

}
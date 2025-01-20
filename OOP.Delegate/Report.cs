namespace OOP.Delegate
{
	public class Report
	{
		// Declaring a Delegate
		public delegate bool SalesCriteria(Employee e);
		
		// Generic method that uses the delegate to filter employees and generate a report
		public void GenerateReport(Employee[] employees, string reportTitle, SalesCriteria criteria)
		{
			Console.WriteLine(reportTitle);
			Console.WriteLine("".PadRight(reportTitle.Length, '-'));
			
			foreach (Employee e in employees) {
				if (criteria(e))
				{
                    Console.WriteLine($"{e.Id} | {e.Name.PadRight(10, ' ')} | {e.Gender} | ${e.TotalSales}");
                }
            }

            Console.WriteLine();
		}
		
		// for sales equal 60,000+
		public void GenerateHighPerformerReport(Employee[] employees)
		{
			Console.WriteLine("Employees with Sales = $60,000+");
            Console.WriteLine("-------------------------------");

			foreach (var e in employees)
			{
				if (e.TotalSales >= 60000m)
				{
					Console.WriteLine($"{e.Id} | {e.Name.PadRight(10, ' ')} | {e.Gender} | ${e.TotalSales}");
				}
			}
            Console.WriteLine();
        }

        // for sales between 30,000 and 60,000
        public void GenerateMidPerformerReport(Employee[] employees)
		{
			Console.WriteLine("Employees with Sales Between $30,000 and $60,000");
            Console.WriteLine("------------------------------------------------");

            foreach (var e in employees)
			{
				if (e.TotalSales >= 30000m && e.TotalSales < 60000m)
				{
					Console.WriteLine($"{e.Id} | {e.Name.PadRight(10, ' ')} | {e.Gender} | ${e.TotalSales}");
				}
			}
            Console.WriteLine();
        }

        // for sales less than 30,000
        public void GenerateLowPerformerReport(Employee[] employees)
		{
			Console.WriteLine("Employees with Sales less than $30,000");
			Console.WriteLine("--------------------------------------");

			foreach (var e in employees)
			{
				if (e.TotalSales < 30000m)
				{
					Console.WriteLine($"{e.Id} | {e.Name.PadRight(10, ' ')} | {e.Gender} | ${e.TotalSales}");
				}
			}
			Console.WriteLine();
		}
	}
}

namespace OOP.Delegate
{
	class Program
	{
		// Delegate declaration
		public delegate void MyDelegate(string message);

		static void Main(string[] args)
		{
			DemonstrateBasicDelegate();
			DemonstrateMulticastDelegate();
			DemonstrateAnonymousMethod();
			DemonstrateLambdaExpression();
			DemonstrateSalesReportWithoutDelegate();
			DemonstrateSalesReportWithDelegate();
		}

		private static void DemonstrateBasicDelegate()
		{
			Console.WriteLine("Basic Delegate Example");
			Console.WriteLine("======================\n");
			var print = new Print();
			MyDelegate del = print.PrintMessage;
			del("Hello, Delegate!");
			ResetConsole();
		}

		private static void DemonstrateMulticastDelegate()
		{
			Console.WriteLine("Multicast Delegate Example");
			Console.WriteLine("==========================\n");
			var print = new Print();
			MyDelegate del = print.PrintMessage;
			del += print.PrintLogMessage;
			del("Hello, Multicast Delegate!");
			ResetConsole();
		}

		private static void DemonstrateAnonymousMethod()
		{
			Console.WriteLine("Anonymous Method Example");
			Console.WriteLine("========================\n");
			MyDelegate del = delegate (string message)
			{
				Console.WriteLine("Anonymous Method Message: " + message);
			};
			del("Hello, Anonymous Method!");
			ResetConsole();
		}

		private static void DemonstrateLambdaExpression()
		{
			Console.WriteLine("Lambda Expression Example");
			Console.WriteLine("=========================\n");
			MyDelegate del = message => Console.WriteLine("Lambda Expression Message: " + message);
			del("Hello, Lambda Expression!");
			ResetConsole();
		}

		private static void DemonstrateSalesReportWithoutDelegate()
		{
			Console.WriteLine("Sales Report Without Delegate");
			Console.WriteLine("=============================\n");

			var employees = GetSampleEmployees();
			var report = new Report();

			report.GenerateHighPerformerReport(employees);
			report.GenerateMidPerformerReport(employees);
			report.GenerateLowPerformerReport(employees);

			ResetConsole();
		}

		private static void DemonstrateSalesReportWithDelegate()
		{
			Console.WriteLine("Sales Report With Delegate");
			Console.WriteLine("==========================\n");

			var employees = GetSampleEmployees();
			var report = new Report();

			// Using anonymous method
			report.GenerateReport(
				employees,
				"Employees with Sales = $60,000+",
				delegate (Employee e) { return e.TotalSales >= 60000m; }
			);

			// Using lambda expressions
			report.GenerateReport(
				employees,
				"Employees with Sales Between $30,000 and $60,000",
				e => e.TotalSales >= 30000m && e.TotalSales < 60000m
			);

			report.GenerateReport(
				employees,
				"Employees with Sales less than $30,000",
				e => e.TotalSales < 30000m
			);

			Console.WriteLine("\nPress any key to exit...");
			Console.ReadKey();
		}

		private static Employee[] GetSampleEmployees()
		{
			return new Employee[]
			{
				new Employee { Id = 1, Name = "Muhammad A", Gender = "M", TotalSales = 65000m },
				new Employee { Id = 2, Name = "Fatma R", Gender = "F", TotalSales = 50000m },
				new Employee { Id = 3, Name = "Zain M", Gender = "M", TotalSales = 60000m },
				new Employee { Id = 4, Name = "Ibrahim A", Gender = "M", TotalSales = 40000m },
				new Employee { Id = 5, Name = "Aliaa A", Gender = "F", TotalSales = 42000m },
				new Employee { Id = 6, Name = "Farah R", Gender = "F", TotalSales = 35000m },
				new Employee { Id = 7, Name = "Nermin A", Gender = "F", TotalSales = 17000m },
				new Employee { Id = 8, Name = "Yahia M", Gender = "M", TotalSales = 15000m }
			};
		}

		private static void ResetConsole()
		{
			Console.WriteLine("\nPress any key to continue...");
			Console.ReadKey();
			Console.Clear();
		}
	}
}
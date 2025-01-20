namespace OOP.Constructor
{
    internal class Program
    {
        private static void Main(string[] args)
        {
            DemonstrateDateConstructors();
            DemonstrateDateFormatting();
        }

        private static void DemonstrateDateConstructors()
        {
            Console.WriteLine("Date Constructor Demonstrations");
            Console.WriteLine("===============================\n");

            // Using year-only constructor
            var date1 = new Date(2025);
            Console.WriteLine($"Year only: {date1.GetDate()}");

            // Using month and year constructor
            var date2 = new Date(3, 2025);
            Console.WriteLine($"Month and year: {date2.GetDate()}");

            // Using full date constructor
            var date3 = new Date(15, 3, 2025);
            Console.WriteLine($"Full date: {date3.GetDate()}");

            // Demonstrating validation
            var invalidDate = new Date(31, 2, 2025); // Invalid - February 31st
            Console.WriteLine($"Invalid date defaults to: {invalidDate.GetDate()}");

            Console.WriteLine("\nPress any key to continue...");
            Console.ReadKey();
            Console.Clear();
        }

        private static void DemonstrateDateFormatting()
        {
            Console.WriteLine("Date Formatting Demonstrations");
            Console.WriteLine("==============================\n");

            var date = new Date(15, 3, 2025);

            Console.WriteLine("Different date formats:");
            Console.WriteLine($"Default format: {date.GetDate()}");
            Console.WriteLine($"DD/MM/YYYY: {date.GetDate("DD/MM/YYYY")}");
            Console.WriteLine($"MM/DD/YYYY: {date.GetDate("MM/DD/YYYY")}");
            Console.WriteLine($"YYYY/MM/DD: {date.GetDate("YYYY/MM/DD")}");

            Console.WriteLine("\nPress any key to exit...");
            Console.ReadKey();
        }
    }
}
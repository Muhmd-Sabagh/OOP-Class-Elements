namespace OOP.Indexers
{
	internal class Program
	{
        static void Main(string[] args)
        {
            DemonstrateIPIndexer();
            Console.WriteLine("\nPress any key to continue to Sudoku demonstration...");
            Console.ReadKey();
            Console.Clear();
            DemonstrateSudokuIndexer();
        }

        private static void DemonstrateIPIndexer()
        {
            Console.WriteLine("IP Address Demonstration");
            Console.WriteLine("========================\n");

            var ip1 = new IP(192, 168, 1, 1);
            Console.WriteLine($"Initial IP Address: {ip1.GetIP}");

            ip1[3] = 5;
            Console.WriteLine($"Modified IP Address: {ip1.GetIP}");

            var ip2 = new IP("172.16.0.2");
            Console.WriteLine($"\nSecond IP Address: {ip2.GetIP}");
            Console.WriteLine("Individual Octets:");
            for (int i = 0; i < 4; i++)
            {
                Console.WriteLine($"Octet {i + 1}: {ip2[i]}");
            }
        }

        private static void DemonstrateSudokuIndexer()
        {
            Console.WriteLine("Sudoku Demonstration");
            Console.WriteLine("====================\n");

            int[,] initialGrid = new int[,] {
                {8, 3, 5, 4, 1, 6, 9, 2, 7},
                {2, 9, 6, 8, 5, 7, 4, 3, 1},
                {4, 1, 7, 2, 9, 3, 6, 5, 8},
                {5, 6, 9, 1, 3, 4, 7, 8, 2},
                {1, 2, 3, 6, 7, 8, 5, 4, 9},
                {7, 4, 8, 5, 2, 9, 1, 6, 3},
                {6, 5, 2, 7, 8, 1, 3, 9, 4},
                {9, 8, 1, 3, 4, 5, 2, 7, 6},
                {3, 7, 4, 9, 6, 2, 8, 1, 5}
            };

            var sudoku = new Sudoku(initialGrid);
            Console.WriteLine("Initial Sudoku grid:");
            Console.WriteLine(sudoku.ToString());

            Console.WriteLine($"\nValue at [5,5]: {sudoku[5, 5]}");

            sudoku[5, 5] = 7;
            Console.WriteLine($"After changing value at [5,5] to 7:");
            Console.WriteLine(sudoku.ToString());
        }
    }
}

namespace OOP.Event
{
	// Main program demonstrating stock price tracking
	internal class Program
	{
		static void Main(string[] args)
		{
			DemonstrateStockPriceChanges();
		}

		private static void DemonstrateStockPriceChanges()
		{
			Console.WriteLine("Stock Price Tracking Demonstration");
			Console.WriteLine("==================================\n");

			// Create a new stock instance
			var stock = new Stock("Amazon", 100m);

			// Subscribe to the price change event
			stock.OnPriceChanged += Stock_OnPriceChanged;

			// Simulate various price changes
			Console.WriteLine($"Initial {stock.Name} price: ${stock.Price}\n");

			// Simulate a trading day
			SimulatePriceChanges(stock);

			// Display daily summary
			DisplayDailySummary(stock);

			// Demonstrate unsubscribing from the event
			Console.WriteLine("\nUnsubscribing from price changes...");
			stock.OnPriceChanged -= Stock_OnPriceChanged;

			// These changes won't be displayed since we unsubscribed
			stock.ChangeStockPriceBy(0.04m);
			stock.ChangeStockPriceBy(-0.03m);

			Console.WriteLine("\nPress any key to exit...");
			Console.ReadKey();
		}

		// Event handler for price changes
		private static void Stock_OnPriceChanged(Stock stock, decimal oldPrice, decimal percentChange)
		{
			// Set color based on price movement
			Console.ForegroundColor =	stock.Price > oldPrice? ConsoleColor.Green :
										stock.Price < oldPrice? ConsoleColor.Red :
										ConsoleColor.Gray;

			// Display price change with arrow indicating direction
			string arrow = stock.Price > oldPrice ? "↑" : stock.Price < oldPrice ? "↓" : "→";
			// Console.WriteLine($"{stock.Name}: ${Math.Round(stock.Price, 2)} {arrow} ({Math.Round(percentChange * 100, 2)}% change)");
			Console.WriteLine($"{stock.Name}: ${stock.Price:F2} {arrow} ({percentChange:P2} change)");

			// Reset color
			Console.ResetColor();
		}

		// Simulate a series of price changes
		private static void SimulatePriceChanges(Stock stock)
		{
			decimal[] changes = new decimal[10];

			for (int i = 0; i < changes.Length; i++)
			{
				changes [i] = Random.Shared.Next(-10, 10) / 100m; // Random numbers from -0.1 to 0.1

				stock.ChangeStockPriceBy(changes[i]);
				Thread.Sleep(1500); // Add delay for better visualization
			}
		}

		// Display daily trading summary
		private static void DisplayDailySummary(Stock stock)
		{
			Console.WriteLine("\nDaily Trading Summary");
			Console.WriteLine("-----------------------");
			Console.WriteLine($"Opening Price: ${stock.OpeningPrice:F2}");
			Console.WriteLine($"Current Price: ${stock.Price:F2}");
			Console.WriteLine($"High: ${stock.HighPrice:F2}");
			Console.WriteLine($"Low: ${stock.LowPrice:F2}");
			Console.WriteLine($"Day Change: ${stock.DayChange:F2} ({stock.DayChangePercentage}%)");
		}
	}
}

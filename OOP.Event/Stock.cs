namespace OOP.Event
{
    // Delegate for handling price change events
    public delegate void PriceChangeHandler(Stock stock, decimal oldPrice, decimal percentageChange);

    // Represents a stock with price change tracking capabilities
    public class Stock
    {
        // Private fields
        private readonly string _name;
        private decimal _price;
        private decimal _openingPrice;
        private decimal _highPrice;
        private decimal _lowPrice;

        // Event declaration for price changes
        public event PriceChangeHandler OnPriceChanged;

        // Properties
        public string Name => _name;
        public decimal Price => _price;
        public decimal OpeningPrice => _openingPrice;
        public decimal HighPrice => _highPrice;
        public decimal LowPrice => _lowPrice;
        public decimal DayChange => _price - _openingPrice;
        public decimal DayChangePercentage => Math.Round((_price - _openingPrice) / _openingPrice * 100, 2);

        // Constructors
        public Stock(string name)
        {
            _name = name;
            _price = 0;
            InitializePriceMetrics();
        }

        public Stock(string name, decimal initialPrice)
        {
            _name = name;
            _price = initialPrice;
            InitializePriceMetrics();
        }

        // Initialize price tracking metrics
        private void InitializePriceMetrics()
        {
            _openingPrice = _price;
            _highPrice = _price;
            _lowPrice = _price;
        }

        // Method to change the stock price by a percentage
        public void ChangeStockPriceBy(decimal percentChange)
        {
            // Store the old price before changes
            decimal oldPrice = _price;

            // Calculate and set the new price
            decimal change = Math.Round(_price * percentChange, 2);
            _price += change;

            // Update high and low prices
            _highPrice = Math.Max(_highPrice, _price);
            _lowPrice = Math.Min(_lowPrice, _price);

            // Trigger the price change event if there are subscribers
            OnPriceChanged?.Invoke(this, oldPrice, percentChange);
        }

        // Reset the daily tracking metrics
        public void ResetDailyMetrics()
        {
            InitializePriceMetrics();
        }
    }
}

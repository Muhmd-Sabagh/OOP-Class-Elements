namespace OOP.Property
{
    // Demonstrates a basic implementation of a property with validation
    public class Dollar
    {
        // Private field to store the amount
        private decimal _amount;

        // Property with getter and setter that includes validation
        public decimal Amount
        {
            get
            {
                return _amount;
            }

            set
            {
                _amount = ValidateAmount(value);
            }
        }

        // Constructor that validates the initial amount
        public Dollar(decimal amount)
        {
            _amount = ValidateAmount(amount);
        }

        // Helper method to validate and round the amount
        private static decimal ValidateAmount(decimal value) => value <= 0 ? 0 : Math.Round(value, 2);
    }

    internal class Program
    {
        static void Main(string[] args)
        {
            // Create a Dollar instance
            Dollar dollar = new Dollar(1.99m);
            // Use the property getter to display the value
            Console.WriteLine($"${dollar.Amount}");

            // Use the property setter
            dollar.Amount = 12.009m;
            Console.WriteLine($"${dollar.Amount}");

            Console.ReadKey();
        }
    }
}
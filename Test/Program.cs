namespace Test
{
    internal class Program
    {
        static void Main(string[] args)
        {
            decimal num;

            for (int i = 0; i < 15; i++)
            {
                num = Random.Shared.Next(-10, 10) / 100m;
                Console.WriteLine($"{num}");
            }
        }
    }
}

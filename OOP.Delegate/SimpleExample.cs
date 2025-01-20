namespace OOP.Delegate
{
    public class Print
	{
		public void PrintMessage(string message)
		{
			Console.WriteLine("The Message is: " + message);
		}

		public void PrintLogMessage(string message) 
		{ 
			Console.WriteLine("Log Message is: " + message);
		}
	}

}

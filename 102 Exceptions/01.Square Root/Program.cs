using System.Security.Principal;

namespace Square_Root
{
    public class Program
    {
        static void Main(string[] args)
        {
			try
			{
                int N = int.Parse(Console.ReadLine());

                if (N < 0)
                {
                    throw new ArgumentOutOfRangeException(nameof(N), "Invalid number.");
                }

                Console.WriteLine(Math.Sqrt(N));
            }
            catch (FormatException ex)
            {
                Console.WriteLine("Data must be digit");
                Console.WriteLine(ex.Message);
            }
			catch (ArgumentOutOfRangeException ex)
			{

                Console.WriteLine(ex.Message);
            }
            finally 
            {
                Console.WriteLine("Goodbye.");
            }
        }
    }
}
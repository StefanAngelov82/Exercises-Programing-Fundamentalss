using System.Threading.Channels;

namespace Applied_Arithmetics
{
    internal class Program
    {
        static void Main(string[] args)
        {
            double[] numbers = Console.ReadLine()
                .Split()
                .Select(double.Parse)
                .ToArray();

            Func<double[], double[]> add = (x) => x.Select(y => y + 1).ToArray();
            Func<double[], double[]> multiply = (x) => x.Select(y => y * 2).ToArray();
            Func<double[], double[]> subtract = (x) => x.Select(y => y - 1).ToArray();        

            string input = String.Empty;

            while ((input = Console.ReadLine()) != "end")
            {
                switch (input)
                {
                    case "add":
                        numbers = add(numbers);
                        break;
                    case "multiply":
                        numbers = multiply(numbers);
                        break;
                    case "subtract":
                        numbers = subtract(numbers);
                        break;
                    case "print":
                        Console.WriteLine(String.Join(" ", numbers));
                        break;
                }
            }
        }        
    }
    
}
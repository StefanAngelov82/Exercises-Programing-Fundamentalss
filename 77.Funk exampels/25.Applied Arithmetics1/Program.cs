using System.Security.Cryptography.X509Certificates;

namespace Applied_Arithmetics1
{
    internal class Program
    {
        public delegate int[] MatOperation(int[] numbers);

        static void Main(string[] args)
        {
            int[] numbers = Console.ReadLine()
                .Split()
                .Select(int.Parse)
                .ToArray();

            Action<int[]> print = (x) => Console.WriteLine(string.Join(" ", x));

            string input = String.Empty; 
            while ((input = Console.ReadLine()) != "end")
            {
                MatOperation mat = Operate(input);

                if (mat == null)
                {
                    print(numbers);
                    continue;
                }

                numbers = mat(numbers);
            }
        }

        private static MatOperation Operate(string  input)
        {
            MatOperation result = null;

            switch (input)
            {
                case "add":
                    result = (x) => x.Select(y => y + 1).ToArray();
                    break;
                case "multiply":
                    result = (x) => x.Select(y => y * 2).ToArray(); 
                    break;
                case "subtract":
                    result = (x) => x.Select(y => y - 1).ToArray(); 
                    break;                
            }

            return result;
        }
    }  
}
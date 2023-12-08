namespace SimpeleCalkulator_2
{
    internal class Program
    {
        static void Main(string[] args)
        {
            int[] numbers = Console.ReadLine()
                .Split()
                .Select(int.Parse)
                .ToArray();

            Stack<int> stack = new Stack<int>(numbers);

            string input = String.Empty;

            while ((input = Console.ReadLine().ToLower()) != "end")
            {
                string[] inputArg = input.Split();

                switch (inputArg[0])
                {
                    case"add":

                        stack.Push(int.Parse(inputArg[1]));
                        stack.Push(int.Parse(inputArg[2]));                        

                        break;
                    case "remove":
                         
                        int number = int.Parse(inputArg[1]);

                        if (stack.Count >= number)
                        {
                            for (int i = 0; i < number; i++)
                            {
                                stack.Pop();
                            }
                        }

                        break;
                }
            }

            Console.WriteLine($"Sum: {stack.Sum()}");
        }
    }
}
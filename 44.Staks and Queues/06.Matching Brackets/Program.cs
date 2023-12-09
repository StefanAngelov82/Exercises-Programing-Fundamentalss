namespace Matching_Brackets
{
    internal class Program
    {
        static void Main(string[] args)
        {
            string input = Console.ReadLine();

            Stack<int> stack = new Stack<int>();

            for (int i = 0; i < input.Length; i++)
            {
                if (input[i] == '(')
                {
                    stack.Push(i);
                }
                if (input[i] == ')')
                {
                    int start = stack.Pop();
                    int end = i;

                    string result = input.Substring(start, end - start + 1);

                    Console.WriteLine(result);
                }
            }
        }
    }
}
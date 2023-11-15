using System.Text;

namespace Treasure_Finder
{
    internal class Program
    {
        static void Main(string[] args)
        {
            int[] shiffer = Console.ReadLine()
                .Split()
                .Select(int.Parse)
                .ToArray();

            string input = String.Empty;

            while ((input = Console.ReadLine()) != "find")
            {
                int j = 0;

                StringBuilder sb = new StringBuilder();

                for (int i = 0; i < input.Length; i++)
                {
                    sb.Append((char)(input[i] - shiffer[j]));

                    j++;
                    if (j == shiffer.Length) j = 0;
                }

                string[] result = (sb.ToString())
                    .Split(new char[] {'&','<','>'}, StringSplitOptions.RemoveEmptyEntries);

                Console.WriteLine($"Found {result[1]} at {result[3]}");

            }
        }
    }
}
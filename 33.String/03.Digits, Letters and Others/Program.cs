using System.Text;

namespace Digits__Letters_and_Others
{
    internal class Program
    {
        static void Main(string[] args)
        {
            string text = Console.ReadLine();
            char[] symbols = text.ToCharArray();

            StringBuilder digits = new StringBuilder();
            StringBuilder symbolss = new StringBuilder();
            StringBuilder letters = new StringBuilder();

            foreach (char symbol in symbols)
            {
                if (char.IsDigit(symbol))
                {
                    digits.Append(symbol);
                }
                else if (char.IsLetter(symbol))
                {
                    letters.Append(symbol);
                }
                else
                {
                    symbolss.Append(symbol);
                }
            }

            Console.WriteLine(digits);
            Console.WriteLine(letters);
            Console.WriteLine(symbolss);
        }
    }
}
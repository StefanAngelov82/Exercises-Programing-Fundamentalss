namespace Letters_Change_Numbers
{
    internal class Program
    {
        static void Main(string[] args)
        {
            string[] text = Console.ReadLine().Split(new string[] { " " }, StringSplitOptions.RemoveEmptyEntries);

            decimal totalSum = 0;
            for (int i = 0; i < text.Length; i++)
            {
                char firstletter = text[i][0];
                char lastletter = text[i][text[i].Length - 1];
                string currentText = text[i].Substring(1, text[i].Length - 2);
                decimal currentnumber = decimal.Parse(currentText);

                if (char.IsUpper(firstletter))
                {
                    currentnumber /= (int)firstletter - 64;
                }
                else
                {
                    currentnumber *= (int)firstletter - 96;
                }

                if (char.IsUpper(lastletter))
                {
                    currentnumber -= (int)lastletter - 64;
                }
                else
                {
                    currentnumber += (int)lastletter - 96;
                }

                totalSum += currentnumber;
            }

            Console.WriteLine($"{totalSum:F2}");

        }
    }
}
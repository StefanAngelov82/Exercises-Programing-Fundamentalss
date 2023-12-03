namespace Exam3
{
    internal class Program
    {
        static void Main(string[] args)
        {
           string text = Console.ReadLine();

            string command = String.Empty;

            while ((command = Console.ReadLine()) != "Done")
            {
                string[] commandArg = command.Split();

                switch (commandArg[0])
                {
                    case "Change":
                        char targetSymbol = char.Parse(commandArg[1]);
                        char replacement = char.Parse(commandArg[2]);

                        text = text.Replace(targetSymbol, replacement);

                        Console.WriteLine(text);
                        break;
                    case "Includes":
                        string substring = commandArg[1];         

                        Console.WriteLine(text.Contains(substring));
                        break;
                    case "End":
                        string targetSubstring = commandArg[1];
                        
                        int startingpoint = text.Length - targetSubstring.Length;

                        string terget = text.Substring(startingpoint);

                        if (targetSubstring == terget)
                        {
                            Console.WriteLine(true);
                        }
                        else
                        {
                            Console.WriteLine(false);
                        }

                        break;
                    case "Uppercase":
                        text = text.ToUpper();

                        Console.WriteLine(text);
                        break;
                    case "FindIndex":

                        char targetSymboll = char.Parse(commandArg[1]);

                        Console.WriteLine(text.IndexOf(targetSymboll));
                        break;
                    case "Cut":

                        int startingIndex = int.Parse(commandArg[1]);
                        int lenght = int.Parse(commandArg[2]);

                        Console.WriteLine(text.Substring(startingIndex, lenght));
                        break;
                }
            }
        }

    }
}
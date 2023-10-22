namespace Phone_Shop
{
    internal class Program
    {
        static void Main(string[] args)
        {
            List<string> phones = Console.ReadLine()
                .Split(", ")
                .ToList();

            string input = String.Empty;

            while ((input = Console.ReadLine()) != "End")
            {
                string[] inputArg = input.Split(new string[] {" - ",":"}, StringSplitOptions.RemoveEmptyEntries);

                switch (inputArg[0])
                {
                    case "Add":

                        if (!phones.Contains(inputArg[1]))
                        {
                            phones.Add(inputArg[1]);
                        } 

                        break;

                    case "Remove":

                        phones.Remove(inputArg[1]);

                        break;

                    case "Bonus phone":

                        int index = phones.IndexOf(inputArg[1]);

                        if (index >= 0)
                        {
                            phones.Insert(index + 1, inputArg[2]);
                        }

                        break;
                    case "Last":

                        if (phones.Contains(inputArg[1]))
                        {
                            phones.Add(inputArg[1]);
                            phones.Remove(inputArg[1]);

                        }

                        break;
                }
            }

            Console.WriteLine(string.Join(", ", phones));
        }
    }
}
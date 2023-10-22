namespace Friend_List_Maintenance
{
    internal class Program
    {
        static void Main(string[] args)
        {
            List<string> names = Console.ReadLine()
                .Split(", ")
                .ToList();            

            string input = String.Empty;
            int blacklistCounter = 0;
            int lostNames = 0;

            while ((input = Console.ReadLine()) != "Report")
            {
                string[] inputArg = input.Split(" ");

                switch (inputArg[0])
                {
                    case "Blacklist":
                        Blacklist(names, inputArg, ref blacklistCounter);
                        break;
                    case "Error":
                        Error(names, inputArg,  ref lostNames);
                        break;
                    case "Change":
                        Change(names, inputArg);
                        break;
                }
            }

            Console.WriteLine($"Blacklisted names: {blacklistCounter}");
            Console.WriteLine($"Lost names: {lostNames}");
            Console.WriteLine(string.Join(" ", names));
        }

        static void Change(List<string> names, string[] inputArg)
        {
            int index = int.Parse(inputArg[1]);
            string name = inputArg[2];

            if (index >= 0 && index < names.Count)
            {
                if (names[index] != "Blacklisted" && names[index] != "Lost")
                {
                    Console.WriteLine($"{names[index]} changed his username to {name}.");
                }

                names[index] = name;
            }
        }

        static void Error(List<string> names, string[] inputArg, ref int lostnames)
        {
            int index = int.Parse(inputArg[1]);

            if (index >= 0 && index < names.Count)
            {
                if (names[index] != "Blacklisted" && names[index] != "Lost")
                {
                    Console.WriteLine($"{names[index]} was lost due to an error.");
                    names[index] = "Lost";
                    lostnames++;
                }
            }
        }

        static void Blacklist(List<string> names, string[] inputArg,  ref int blacklistCounter)
        {
            string name = inputArg[1];
            int index = names.IndexOf(name);

            if (index >= 0)
            {
                Console.WriteLine($"{name} was blacklisted.");
                names[index] = "Blacklisted";
                blacklistCounter++;
            }
            else
            {
                Console.WriteLine($"{name} was not found.");
            }
        }
    }
}
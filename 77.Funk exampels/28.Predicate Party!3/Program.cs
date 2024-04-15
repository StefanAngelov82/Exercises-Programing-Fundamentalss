using System.Diagnostics;

namespace Predicate_Party_3
{
    public delegate bool Filter(string name);

    internal class Program
    {
        static void Main(string[] args)
        {
            List<string> gests = Console.ReadLine()
                .Split(" ", StringSplitOptions.RemoveEmptyEntries).ToList();

            string input = string.Empty;

            while ((input = Console.ReadLine()) != "Party!")
            {
                ProssesGests(input, ref gests);
            }

            Console.WriteLine(String.Join(" ", gests));
        }

        private static void ProssesGests(string input, ref List<string> gests)
        {
            string[] inputArg = input.Split();
            List<string> copyGests = new List<string>(gests);

            Filter filter = FilteringGests(inputArg);

            switch (inputArg[0])
            {
                case "Double":
                    gests = copyGests.FindAll(x => filter(x))
                    .Concat(gests)
                    .OrderBy(x => x)
                    .ToList();
                    break;

                case "Remove":
                    gests.RemoveAll(x => filter(x));
                    break;
            }
        }

        private static Filter FilteringGests(string[] inputArg)
        {

            Predicate<string> predicate =
                (x) =>
                {
                    if (inputArg[1] == "StartsWith")
                    {
                        return x.StartsWith(inputArg[2]);
                    }
                    else if (inputArg[1] == "EndsWith")
                    {
                        return x.EndsWith(inputArg[2]);
                    }
                    else
                    {
                        int length = int.Parse(inputArg[2]);
                        return x.Length == length;
                    }
                };

            return new Filter(predicate);
        }
    }
}
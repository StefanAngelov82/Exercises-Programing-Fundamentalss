

namespace Predicate_Party_
{
    internal class Program
    {
        static void Main(string[] args)
        {
            List<string> gests = Console.ReadLine()
                .Split()
                .ToList();

            string input = String.Empty;           

            while ((input = Console.ReadLine()) != "Party!")
            {
                string[] inputArg = input.Split();

                string criteria = inputArg[1];
                string nameFeature = inputArg[2];

                Func<string, bool> check = NameProcessing(criteria, nameFeature);

                switch (inputArg[0])
                {
                    case "Remove":

                         gests = gests.FindAll(x => !check(x));
                        
                        break;
                    case "Double":

                        gests = gests.FindAll(x => check(x))
                                    .Concat(gests)
                                    .OrderBy(x => x)
                                    .ToList();
                        break;

                }
            }

            if (gests.Count != 0)
                Console.WriteLine($"{string.Join(", ", gests)} are going to the party!");

            else
                Console.WriteLine("Nobody is going to the party!");


        }

        static Func<string, bool> NameProcessing(string criteria, string nameFeature)
        {
            if (criteria == "StartsWith")
            {
                return x => x.IndexOf(nameFeature) == 0;                
            }
            else if (criteria == "EndsWith")
            {
                return x => x.LastIndexOf(nameFeature) == x.Length - nameFeature.Length;
            }
            else
            {
                return x => x.Length == int.Parse(nameFeature);
            }
        }
    }
}
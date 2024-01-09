namespace The_Party_Reservation_Filter_Module
{
    internal class Program
    {
        static void Main(string[] args)
        {
            List<string> gests = Console.ReadLine()
                .Split()
                .ToList();

            string input = String.Empty;

            List<Tuple<string, string>> filterData = new List<Tuple<string, string>>();

            while ((input = Console.ReadLine()) != "Print")
            {
                string[] inputArg = input.Split(';');

                string command = inputArg[0];
                string filterType = inputArg[1];
                string filterParam = inputArg[2];

                Tuple<string, string> current = new Tuple<string, string>(filterType, filterParam);

                if (command.StartsWith("Add"))
                {
                    filterData.Add(current);
                }
                else if (command.StartsWith("Remove"))
                {
                    filterData.Remove(current);
                }
            }

            int count = 0;

            while (count <= filterData.Count - 1)
            { 
                string filterType = filterData[count].Item1;
                string filterParam = filterData[count].Item2;

                Predicate<string> check = Filter(filterType, filterParam);

                gests.RemoveAll(check);

                count++;
            }

            Console.WriteLine(string.Join(" ", gests));
        }

        static Predicate<string> Filter(string filterType, string filterParam)
        {
            if (filterType.StartsWith("Starts"))
            {
                return x => x.StartsWith(filterParam);
            }
            else if (filterType.StartsWith("Ends"))
            {
                return x =>  x.EndsWith(filterParam);
            }
            else if (filterType.StartsWith("Length"))
            {
                return x => x.Length == int.Parse(filterParam);
            }
            else
            {
                return x => x.Contains(filterParam);
            }
        }

        
    }
}
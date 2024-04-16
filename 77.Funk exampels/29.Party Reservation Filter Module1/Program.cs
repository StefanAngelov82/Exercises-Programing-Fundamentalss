namespace Party_Reservation_Filter_Module1
{
    public delegate bool Filter(string name);

    internal class Program
    {
        static void Main(string[] args)
        {
            List<string> names = Console.ReadLine().Split().ToList();

            List<Tuple<string, string>> filters = new List<Tuple<string, string>>();

            string? input = String.Empty;

            while ((input = Console.ReadLine()) != "Print")
            {
                ProcessingGests(ref filters, input);
            }

            foreach (var tuple in filters)
            {
                Filter filter = FilterGenerator(tuple);
                names.RemoveAll(x => filter(x));
            }

            Console.WriteLine(String.Join(" ", names));
        }

        private static void ProcessingGests( ref List<Tuple<string, string>> filters, string? input)
        {
            string[] inputArg = input.Split(";");
            
            string filterType = inputArg[1];
            string filterParam = inputArg[2];

            Tuple<string, string> tuple = new (filterType, filterParam); 

            switch (inputArg[0])
            {
                case "Add filter":
                    filters.Add(tuple);
                    break;
                case "Remove filter":
                    filters.Remove(tuple);
                    break;
            }
        }

        private static Filter FilterGenerator(Tuple<string, string> tuple)
        {
            Predicate<string> predicate = null;

            string filterType = tuple.Item1;           

            switch (filterType)
            {
                case "Starts with":
                    predicate = (x) => x.StartsWith(tuple.Item2); 
                    break;

                case "Ends with":
                    predicate = (x) => x.EndsWith(tuple.Item2);
                    break;

                case "Length":
                    predicate = (x) => x.Length == int.Parse(tuple.Item2);
                    break;

                case "Contains":
                    predicate = (x) => x.Contains(tuple.Item2);
                    break;
            }

            return new Filter(predicate);
        }
    }
}
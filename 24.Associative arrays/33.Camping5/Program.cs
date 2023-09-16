namespace Camping5
{
    internal class Program
    {
        static void Main(string[] args)
        {
            Dictionary<string, Dictionary<string, int>> peoplesData = new Dictionary<string, Dictionary<string, int>>(); 

            string input = String.Empty;

            while ((input = Console.ReadLine()) != "end")
            {
                string[] inputArg = input
                    .Split(' ')
                    .ToArray();

                string name  = inputArg[0];
                string carModel = inputArg[1];
                int nights = int.Parse(inputArg[2]);

                if (!peoplesData.ContainsKey(name))
                {
                    peoplesData[name] = new Dictionary<string, int>();
                }

                if (!peoplesData[name].ContainsKey(carModel))
                {
                    peoplesData[name][carModel] = nights;
                }                
            }

            peoplesData = peoplesData
                .OrderByDescending(x => x.Value.Count)
                .ThenBy(x => x.Key.Length)
                .ToDictionary(x => x.Key, y => y.Value);

            foreach (var name in peoplesData.Keys)
            {
                Console.WriteLine($"{name}: {peoplesData[name].Count}");

                foreach (var kvp in peoplesData[name])
                {
                    Console.WriteLine($"***{kvp.Key}");
                }

                Console.WriteLine($"Total stay: {peoplesData[name].Values.Sum()} nights");
                Console.WriteLine(new string('-', 50));
            }
        }
    }
}
namespace Courses
{
    internal class Program
    {
        static void Main(string[] args)
        {
            Dictionary<string, List<string>> data = new Dictionary<string, List<string>>();
            
            string input = String.Empty;

            while ((input = Console.ReadLine()) is not "end")
            {
                string[] inputArg = input.Split(" : ");

                string coureseName = inputArg[0];
                string studentName = inputArg[1];

                if (!data.ContainsKey(coureseName))
                {
                    data[coureseName] = new List<string>();
                }

                data[coureseName].Add(studentName);
            }

            foreach (var kvp in data)
            {
                Console.WriteLine($"{kvp.Key}: {kvp.Value.Count}");

                foreach (var names in kvp.Value)
                {
                    Console.WriteLine($"-- {names}");
                }
            }
        }
    }
}
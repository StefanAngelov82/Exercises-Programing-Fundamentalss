using System.Diagnostics.Metrics;
using System.Linq;
using System.Threading.Channels;

namespace LINQuistics
{
    internal class Program
    {
        static void Main(string[] args)
        {
            Dictionary<string, HashSet<string>> oparation = new Dictionary<string, HashSet<string>>();

            string input = String.Empty;

            while ((input = Console.ReadLine()) != "exit")
            {
                string[] inputArg = input
                    .Split(new string[] { ".", "()" }, StringSplitOptions.RemoveEmptyEntries);

                if (input.Contains('.'))
                {
                    string collection = inputArg[0];

                    if (!oparation.ContainsKey(collection))
                    {
                        oparation.Add(collection, new HashSet<string>());
                    }

                    for (int i = 1; i < inputArg.Length; i++)
                    {
                        oparation[collection].Add(inputArg[i]);
                    }
                }
                else
                {                  

                    string metod = inputArg[0];


                    if (inputArg.Length == 1)
                    {                        
                        int number;


                        if (int.TryParse(metod, out number))
                        {
                            oparation.Values
                                .OrderByDescending(x => x.Count())
                                .First()
                                .OrderBy(x => x.Length)
                                .Take(number)
                                .ToList()
                                .ForEach(x => Console.WriteLine($"* {x}"));
                        }

                        else if(oparation.ContainsKey(metod))
                        {
                            oparation[metod]
                                .OrderByDescending(x => x.Length)
                                .ThenByDescending(x => x.Distinct().Count())
                                .ToList()
                                .ForEach(x => Console.WriteLine($"* {x}"));
                        }
                    }                   
                }
            }
            
            input = Console.ReadLine();

            string[] inputArg1 = input.Split(' ');

            string metod1 = inputArg1[0];
            string selection = inputArg1[1];

            if (selection == "collection")
            {


                foreach (var kvp in oparation
                    .Where(x => x.Value.Contains(metod1))
                    .OrderByDescending(x => x.Value.Count)
                    .ThenByDescending(x => x.Value.Min(x => x.Length)))
                {
                    Console.WriteLine(kvp.Key);
                }
                
            
            }
            else
            {
                foreach (var kvp in oparation
                    .Where(x => x.Value.Contains(metod1))
                    .OrderByDescending(x => x.Value.Count)
                    .ThenByDescending(x => x.Value.Min(x => x.Length)))
                {
                    Console.WriteLine(kvp.Key);

                    foreach (var methodName in kvp.Value.OrderByDescending(x => x.Count()))
                    {
                        Console.WriteLine($"* {methodName}");
                    }
                }
            }
            





        }
    }
}
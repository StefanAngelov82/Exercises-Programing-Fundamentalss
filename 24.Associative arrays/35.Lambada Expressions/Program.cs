namespace Lambada_Expressions
{
    internal class Program
    {
        static void Main(string[] args)
        {
            Dictionary<string, Dictionary<string, string>> lamdaData = new Dictionary<string, Dictionary<string, string>>();
            
            string input = String.Empty;

            while ((input = Console.ReadLine()) != "lambada")
            {
                if (input == "dance")
                {
                    // lamdaData = lamdaData.ToDictionary(x => x.Key , y => y.Value.ToDictionary(d => d.Key, z => z.Key + "." + z.Value));

                    var selector = lamdaData.Keys.ToList();
                    foreach (var key in selector)
                    {
                        var innerkeys = lamdaData[key].Keys.ToList();
                        foreach(var innerkey in innerkeys)
                        {
                            lamdaData[key][innerkey] = innerkey + "." + lamdaData[key][innerkey];
                        }
                    }
                }
                else
                {
                    string[] inputArg = input.Split(new string[] {" => ","."}, StringSplitOptions.RemoveEmptyEntries );

                    string selector = inputArg[0];
                    string selectorObject = inputArg[1];
                    string property = inputArg[2];

                    if (!lamdaData.ContainsKey(selector))
                    {
                        lamdaData[selector] = new Dictionary<string, string>();
                    }

                    lamdaData[selector][selectorObject] = property;
                }
            }

            foreach (var selector in lamdaData.Keys)
            {
                foreach (var property in lamdaData[selector])
                {                    
                    Console.WriteLine($"{selector} => {property.Key}.{property.Value}");
                }             
               
            }
        }
    }
}
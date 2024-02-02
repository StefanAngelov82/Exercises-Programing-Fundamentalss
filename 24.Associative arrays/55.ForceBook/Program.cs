namespace ForceBook
{
    internal class Program
    {
        static void Main(string[] args)
        {
            Dictionary<string, List<String>>  forceBook = new Dictionary<string, List<String>>();

            string input = String.Empty;

            while ((input = Console.ReadLine())  != "Lumpawaroo")
            {
                if (input.Contains("|"))
                {
                    string forceSide = input.Split(" | ")[0];
                    string forceUser = input.Split(" | ")[1];

                    if (!forceBook.ContainsKey(forceSide))                    
                        forceBook[forceSide] = new List<string>();

                    if (!forceBook.Values.Any(x =>x.Contains(forceUser)))
                    {
                        if (!forceBook[forceSide].Contains(forceUser))
                            forceBook[forceSide].Add(forceUser);
                    }                                    
                }
                else
                {
                    string forceSide = input.Split(" -> ")[1];
                    string forceUser = input.Split(" -> ")[0];

                    if (!forceBook.ContainsKey(forceSide))
                        forceBook[forceSide] = new List<string>(); 

                    foreach (var kvp in forceBook)
                    {
                        if (kvp.Value.Contains(forceUser))                        
                            kvp.Value.Remove(forceUser);                      
                    }

                    forceBook[forceSide].Add(forceUser);

                    Console.WriteLine($"{forceUser} joins the {forceSide} side!");
                }               
            }

            foreach (var kvp in forceBook.OrderByDescending(x =>x.Value.Count).ThenBy(x => x.Key))
            {
                if (kvp.Value.Count > 0)
                {
                    Console.WriteLine($"Side: {kvp.Key}, Members: {kvp.Value.Count}");

                    foreach (var name in kvp.Value.OrderBy(x => x))
                    {
                        Console.WriteLine($"! {name}");
                    }
                }
            }
        }
    }
}
using System.Security.Cryptography.X509Certificates;

namespace Websites
{
    internal class Program
    {
        static void Main(string[] args)
        {
            string input = String.Empty;

            List<Website> data = new List<Website>();

            while ((input = Console.ReadLine()) != "end")
            {
                data.Add(Website.ParseData(input));
            }

            foreach (var website in data)
            {
                Console.Write($"https://www.{website.Host}.{website.Domain}");

                if (website.Queries.Count > 0)
                {
                    Console.Write("/query?=");

                    bool isfirst = true;

                    foreach (var query in website.Queries)
                    {

                        if (isfirst)
                        {
                            Console.Write($"[{query}]");
                            isfirst = false;
                        }
                        else
                        {
                            Console.Write($"&[{query}]");
                        }                        
                    }                    
                }

                Console.WriteLine();
            }
        }
    }
    class Website
    {
        public string Host { get; set; }
        public string Domain { get; set; }
        public List<string> Queries { get; set; }


        public Website(string host, string domain, List<string> queries)
        {
            Host = host;
            Domain = domain;
            Queries = queries;
        }

        public static Website ParseData(string input)
        {
            string[] inputArgs = input
                .Split(new string[] {" | ",","}, StringSplitOptions.RemoveEmptyEntries);

            string host = inputArgs[0];
            string domain = inputArgs[1];

            List<string> queries = new List<string>();

            for (int i = 2; (inputArgs.Length > 2) && (i < inputArgs.Length); i++)
            {
                queries.Add(inputArgs[i]);
            }

            return new Website(host, domain, queries);
        }
    }


}
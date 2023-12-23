using System;
using System.Collections.Generic;
using System.Reflection.Metadata;
using System.Threading.Channels;

namespace User_Logs
{
    internal class Program
    {
        static void Main(string[] args)
        {
            SortedDictionary<string, User> data = new SortedDictionary<string, User>();

            string input = String.Empty;

            while ((input = Console.ReadLine()) != "end")
            {
                DataInput(data, input);
            }

            Printing(data);

        }

        private static void Printing(SortedDictionary<string, User> data)
        {
            foreach (var kvp in data)
            {
                Console.WriteLine($"{kvp.Key}:");

                int counter = 1;

                foreach (var IP in kvp.Value.IP_Massage)
                {
                    Console.Write($"{IP.Key} -> {IP.Value.Count}");
                    Console.WriteLine(counter == kvp.Value.IP_Massage.Count ? "." : ",");

                    counter++;
                }
            }
        }

        private static void DataInput(SortedDictionary<string, User> data, string input)
        {
            string[] inputArg = input
                .Split(new string[] { "=", " ", "='", "' " }, StringSplitOptions.RemoveEmptyEntries);

            string userName = inputArg[5];
            string IPAddress = inputArg[1];
            string massage = inputArg[3];

            if (!data.ContainsKey(userName))
            {
                User current = new User(userName);

                data.Add(userName, current);
            }

            if (!data[userName].IP_Massage.ContainsKey(IPAddress))
            {
                data[userName].IP_Massage[IPAddress] = new List<string>();
            }

            data[userName].IP_Massage[IPAddress].Add(massage);
        }
    }
    class User
    {
        public string Name { get; set; }
        public Dictionary<string, List<string>> IP_Massage { get; set; }

        public User(string name)
        {
            this.Name = name;
            this.IP_Massage = new Dictionary<string, List<string>>();
        }
    }
}

using Microsoft.Win32;
using System.Threading.Channels;

namespace SoftUni_Parking
{
    internal class Program
    {
        static void Main(string[] args)
        {
            Dictionary<string, string> register = new Dictionary<string, string>();

            int N = int.Parse(Console.ReadLine());

            for (int i = 0; i < N; i++)
            {
                string[] input = Console.ReadLine().Split();


                if (input[0] == "register")
                {
                    Register(input, register);
                }
                else
                {
                    Unregister(input, register);
                }
            }

            foreach (var kvp in register)
            {
                Console.WriteLine($"{kvp.Key} => {kvp.Value}");
            }
        }
        static void Register(string[] input, Dictionary<string, string> register)
        {
            string name = input[1];
            string licensePlate = input[2];

            if (register.ContainsKey(name))
            {
                Console.WriteLine($"ERROR: already registered with plate number {register[name]}");
            }
            else
            {
                register.Add(name, licensePlate);

                Console.WriteLine($"{name} registered {licensePlate} successfully");
            }            
        }

        static void Unregister(string[] input, Dictionary<string, string> register)
        {
            string name = input[1];
                       
            if (!register.ContainsKey(name))
            {
                Console.WriteLine($"ERROR: user {name} not found");
            }
            else
            {
                register.Remove(name);
                Console.WriteLine($"{name} unregistered successfully");
            }
        }
    }

    
   


    
}
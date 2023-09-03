using System;
using System.Collections.Generic;

namespace User_Logins1
{
    internal class Program
    {
        static void Main(string[] args)
        {
            Dictionary<string, string> passwordLog = new Dictionary<string, string>();

            string command = String.Empty;
            int failLog = 0;

            while ((command = Console.ReadLine()) != "login")
            {
                string name = CommandArg(command, 0);
                string pass = CommandArg(command, 1);

                passwordLog[name] = pass;
            }

            while ((command = Console.ReadLine()) != "end")
            {
                string name = CommandArg(command, 0);
                string pass = CommandArg(command, 1);

                if (passwordLog.ContainsKey(name) && passwordLog.ContainsValue(pass))
                {
                    Console.WriteLine($"{name}: logged in successfully");
                }
                else
                {
                    Console.WriteLine($"{name}: login failed");
                    failLog++;
                }               
            }

            Console.WriteLine($"unsuccessful login attempts:{failLog}");

        }
        static string CommandArg(string command, int arg)
        {
            string[] commandArg = command.Split(" -> "); 

            if (arg == 0)   return commandArg[0];
            else            return commandArg[1];
        }
    }
}

namespace User_Database
{
    internal class Program
    {
        static void Main(string[] args)
        {
            Dictionary<string, string> users = new Dictionary<string, string>();
            Dictionary<string, string> loged = new Dictionary<string, string>();

            if (File.Exists("users.txt"))
            {
                using (StreamReader read = new StreamReader("users.txt"))
                {
                    while (!read.EndOfStream)
                    {
                        users.Add(read.ReadLine(), read.ReadLine());
                    }
                }
            }           

            string input = String.Empty;

            while ((input = Console.ReadLine()) != "exit")
            {
                switch (CommandRecagnition(input, 0))
                {
                    case "register":
                        RegUser(users, input);
                        break;
                    case "login":
                        LogUser(loged, input, users);
                        break;
                    case "logout":
                        LogOut(loged, input);
                        break;
                }
            }

            using (StreamWriter write = new StreamWriter("users.txt"))
            {
                foreach (var user in users)
                {
                    write.WriteLine($"{user.Key}");
                    write.WriteLine($"{user.Value}");    
                }
            }

        }

        static void LogOut(Dictionary<string, string> loged, string input)
        {
            string username = CommandRecagnition(input, 1);

            if (!loged.ContainsKey(username))
            {
                Console.WriteLine("There is no currently logged in user.");
            }
            else
            {
                loged.Remove(username);
            }
        }

        static void LogUser(Dictionary<string, string> loged, string input, Dictionary<string, string> users)
        {
            string username = CommandRecagnition(input, 1);
            string passwords = CommandRecagnition(input, 2);

            if (loged.ContainsKey(username)) Console.WriteLine("There is already a logged in user.");
            else if (!users.ContainsKey(username)) Console.WriteLine("There is no user with the given username.");
            else if (users[username] != passwords) Console.WriteLine("The password you entered is incorrect.");
            else loged.Add(username, passwords);
        }

        static void RegUser(Dictionary<string, string> users, string input)
        {
            string username = CommandRecagnition(input, 1);
            string passwords = CommandRecagnition(input, 2);
            string confirmPass = CommandRecagnition(input, 3);

            if (users.ContainsKey(username)) Console.WriteLine("The given username already exists.");
            else if (passwords != confirmPass) Console.WriteLine("The two passwords must match.");
            else users.Add(username, passwords);
        }

        static string CommandRecagnition(string input, int shiffer)
        {
            string[] inputArg = input.Split();

            if (shiffer == 0) return inputArg[0];
            else if (shiffer == 1) return inputArg[1];
            else if (shiffer == 2) return inputArg[2];
            else return inputArg[3];
        }

    }
}
using System.Reflection.Metadata;
using System.Xml.Linq;

namespace Exam1
{
    internal class Program
    {
        static void Main(string[] args)
        {
            string input = String.Empty;

            Dictionary<string, User> data = new Dictionary<string, User>();

            while ((input = Console.ReadLine()) != "Log out")
            {
                string[] inputArg = input.Split(": ");

                switch (inputArg[0])
                {
                    case "New follower":
                        string userName = inputArg[1];

                        if (!data.ContainsKey(userName))
                        {
                            User current = new User(userName,0 , 0);
                            data.Add(userName, current);
                        }
                        break;
                    case "Like":

                        string name = inputArg[1];
                        int like = int.Parse(inputArg[2]);

                        if (!data.ContainsKey(name))
                        {
                            User current = new User(name, like, 0);
                            data.Add(name, current);
                        }
                        else
                        {
                            data[name].Likes += like;
                        }

                        break;
                    case "Comment":
                        string user = inputArg[1];                        

                        if (!data.ContainsKey(user))
                        {
                            User current = new User(user, 0, 1);
                            data.Add(user, current);
                        }
                        else
                        {
                            data[user].Comments++;
                        }
                        break;
                    case "Blocked":
                        string targetName = inputArg[1];

                        if (!data.ContainsKey(targetName))
                        {
                            Console.WriteLine($"{targetName} doesn't exist.");
                        }
                        else
                        {
                           data.Remove(targetName);
                        }
                        break;
                }
            }

            Console.WriteLine($"{data.Count} followers");
            foreach (var person in data)
            {
                Console.WriteLine($"{person.Key}: {person.Value.Likes + person.Value.Comments}");
            }

        }
    }
    class User
    {
        public string Name { get; set; }
        public int Likes { get; set; }
        public int Comments { get; set; }
       
        public User(string name, int likes, int comments)
        {
            this.Name = name;
            this.Likes = likes;
            this.Comments = comments;
        }
    }
}
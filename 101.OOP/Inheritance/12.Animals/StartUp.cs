using System;
using System.Runtime.CompilerServices;

namespace Animals
{
    public class StartUp
    {
        public static void Main(string[] args)
        {
            string input = string.Empty;

            while ((input = Console.ReadLine()) != "Beast!")
            {
                string[] inputArg = Console.ReadLine()
                    .Split(" ", StringSplitOptions.RemoveEmptyEntries);

                string name = inputArg[0];
                int age = int.Parse(inputArg[1]);
                string gender = inputArg[2];

                switch (input)
                {
                    case "Cat":
                        Cat cat = new Cat (name, age, gender);
                        Console.WriteLine(cat.ToString());                        
                        break;

                    case "Dog":
                        Dog dog = new Dog (name, age, gender);
                        Console.WriteLine(dog.ToString());
                        break;

                    case "Frog":
                        Frog frog = new Frog(name, age, gender);
                        Console.WriteLine(frog.ToString());
                        break;

                    case "Kitten":
                        Kitten kitten = new Kitten(name, age);
                        Console.WriteLine(kitten.ToString());
                        break;

                    case "Tomcat":
                        Tomcat tomcat = new Tomcat(name, age);
                        Console.WriteLine(tomcat.ToString());
                        break;
                }                
            }
        }
    }
}

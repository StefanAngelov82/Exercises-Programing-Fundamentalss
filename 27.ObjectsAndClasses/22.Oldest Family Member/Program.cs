using System.Net.WebSockets;
using System.Security.Cryptography.X509Certificates;

namespace Oldest_Family_Member
{
    internal class Program
    {
        static void Main(string[] args)
        {
            int N = int.Parse(Console.ReadLine());

            Family fm = new Family();

            for (int i = 0; i < N; i++)
            {
                Person person = Person.DataParse(Console.ReadLine());

                fm.AddMember(person);                
            }
           
            Console.WriteLine(fm.GetOldestMember());
        }
    }
    class Person
    {
        public string Name { get; set; }
        public int Age { get; set; }

        public Person(string name, int age)
        {
            this.Name = name;
            this.Age = age;
        }

        public static Person DataParse(string input)
        {
            string[] inputArg = input.Split();

            return new Person(inputArg[0], int.Parse(inputArg[1]));
        }

        public override string ToString()
        {
            return $"{this.Name} {this.Age}";
        }

    }

    class Family 
    {
        public List<Person> Members { get; set; }

        public Family()
        {
            this.Members = new List<Person>();
        }

        public void AddMember(Person newperson)
        {
            this.Members.Add(newperson);
        }

        public Person GetOldestMember()
        {
            Person person = this.Members.OrderByDescending(x => x.Age).First();

            return person;
        }
    }

    
}
using System.Threading.Channels;

namespace Filter_by_Age
{
    internal class Program
    {
        static void Main(string[] args)
        {
            List<Person> list = ReadPeople();

            string condition = Console.ReadLine();
            int AgeThreshold = int.Parse(Console.ReadLine());
            string Format = Console.ReadLine();

            //Func<Person, bool> check =
            //    (x) =>
            //    {
            //        if (condition == "younger") return x.Age < AgeThreshold;
            //        else return x.Age >= AgeThreshold;
            //    };

            //Func<Person, string> format =
            //    (y) =>
            //    {
            //        if (Format == "name") return y.Name;
            //        else if (Format == "age") return y.Age.ToString();
            //        else return y.Name + " - " + y.Age;
            //    };

            Func<Person, bool> check = Check(condition, AgeThreshold);
            Action<Person> format = Format1(Format);

            list.Where(check)
                .ToList()
                .ForEach(format);
        }

        private static Action<Person> Format1(string Format)
        {
            if      (Format == "name")  return p => Console.WriteLine(p.Name);
            else if (Format == "age")   return p => Console.WriteLine(p.Age.ToString()); 
            else                        return p => Console.WriteLine(p.Name + " - " + p.Age);
        }

         private static Func<Person, bool> Check(string condition, int AgeThreshold)
         {
            if (condition == "younger")    return x => x.Age < AgeThreshold;
            else                           return  x => x.Age >= AgeThreshold;            
         }

        private static List<Person> ReadPeople()
        {
            int N = int.Parse(Console.ReadLine());

            List<Person> list = new List<Person>();

            for (int i = 0; i < N; i++)
            {
                string[] inputArg = Console.ReadLine()
                    .Split(new string[] { ", " }, StringSplitOptions.RemoveEmptyEntries);

                string name = inputArg[0];
                int age = int.Parse(inputArg[1]);

                list.Add(new Person(name, age));
            }

            return list;
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
        }
    }
}
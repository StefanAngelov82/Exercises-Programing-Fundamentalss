namespace Filter_by_Age
{
    internal class Program
    {
        static void Main(string[] args)
        {
            int N = int.Parse(Console.ReadLine());

            List<Person> list = new List<Person>();

            for (int i = 0; i < N; i++)
            {
                string[] inputArg = Console.ReadLine()
                    .Split(new string[] {", " }, StringSplitOptions.RemoveEmptyEntries);

                string name = inputArg[0];
                int age = int.Parse(inputArg[1]);

                Person current = new Person(name, age);
                list.Add(current);
                
            }

            string condition = Console.ReadLine();
            int AgeThreshold = int.Parse(Console.ReadLine());
            string Format = Console.ReadLine();

            Func<Person , bool> check =
                (x) =>
                {
                    if (condition == "younger") return x.Age < AgeThreshold;
                    else                return x.Age >= AgeThreshold;                
                };

            Func<Person, string> format =
                (y) =>
                {
                    if      (Format == "name")   return y.Name;
                    else if (Format == "age")    return y.Age.ToString();
                    else                    return y.Name + " - " + y.Age;             
                };

            list.Where(x => check(x))
                .ToList()
                .ForEach(x => Console.WriteLine(format(x)));
            
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
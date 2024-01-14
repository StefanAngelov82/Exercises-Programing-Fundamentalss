namespace DefiningClasses
{
    public class StartUp
    {
        static void Main()
        {
            int N = int.Parse(Console.ReadLine());

            Family Petrovi = new Family();

            for (int i = 0; i < N; i++)
            {
                string[] input = Console.ReadLine().Split();

                string name = input[0];
                int age = int.Parse(input[1]);

                Person current = new Person(name, age);

                Petrovi.AddMember(current);                
            }

            Person oldest = Petrovi.GetOldestMember();

            Console.WriteLine($"{oldest.Name} {oldest.Age}");
        }
    }
}
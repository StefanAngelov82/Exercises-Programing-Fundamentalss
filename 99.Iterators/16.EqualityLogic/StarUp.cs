namespace EqualityLogic
{
    public class StarUp
    {
        static void Main(string[] args)
        {
            HashSet <Person> set = new HashSet <Person> ();
            SortedSet<Person>sortetdSet = new SortedSet <Person> ();

            int N = int.Parse(Console.ReadLine());


            for (int i = 0; i < N; i++)
            {
                string[] inputArg = Console.ReadLine()
                    .Split(new string[] { " " }, StringSplitOptions.RemoveEmptyEntries);

                string name = inputArg[0];
                int age = int.Parse(inputArg[1]);

                Person current = new Person (name, age);

                set.Add (current);
                sortetdSet.Add (current);

            }

            Console.WriteLine(set.Count);
            Console.WriteLine(sortetdSet.Count);
        }
    }
}
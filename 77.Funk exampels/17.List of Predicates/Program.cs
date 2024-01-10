namespace List_of_Predicates
{
    internal class Program
    {
        static void Main(string[] args)
        {
            int N = int.Parse(Console.ReadLine());

            List<int> list = new List<int>();

            for (int i = 1; i <= N; i++)
            {
                list.Add(i);
            }

            int[] dividers = Console.ReadLine()
                .Split()
                .Select(int.Parse)
                .ToArray();

            Predicate<int> check =
                (x) =>
                {
                    bool isDiv = true;

                    for (int i = 0; i < dividers.Length; i++)
                    {
                        if (x % dividers[i] != 0)
                        {
                            isDiv = false;
                            break;
                        }
                    }

                    return isDiv;
                };

            list.FindAll(check).ToList().ForEach(x => Console.Write($"{x} "));

        }

    }
}
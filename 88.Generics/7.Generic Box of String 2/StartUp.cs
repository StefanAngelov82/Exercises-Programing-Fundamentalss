using GenericBoxofString;

namespace GenericBoxOfString
{
    public class StartUp
    {
        static void Main()
        {
            int N = int.Parse(Console.ReadLine());

            for (int i = 0; i < N; i++)
            {
                int data = int.Parse( Console.ReadLine());

                Box<int> box = new Box<int>(data);

                Console.WriteLine(box);
            }
        }
    }
}
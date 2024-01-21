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
                string data =  Console.ReadLine();

                Box<string> box = new Box<string>(data);

                Console.WriteLine(box);
            }
        }
    }
}
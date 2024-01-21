namespace Tuple
{
    public class StartUp
    {
        static void Main(string[] args)
        {
            string[] input = Console.ReadLine().Split();

            string name = input[0] + " " + input[1];
            string address = input[2];

            Tuple<string, string> data = new Tuple<string, string>(name, address);

            Console.WriteLine(data);

            string[] input1 = Console.ReadLine().Split();

            name = input1[0];
            int beers = int.Parse(input1[1]);

            Tuple<string, int> data1  = new Tuple<string, int>(name, beers);

            Console.WriteLine(data1);

            string[] input2 = Console.ReadLine().Split();
            int number1 = int.Parse(input2[0]);
            double number2 = double.Parse(input2[1]);

            Tuple<int, double> data3 = new Tuple<int, double>(number1,number2);

            Console.WriteLine(data3);
        }
    }
}
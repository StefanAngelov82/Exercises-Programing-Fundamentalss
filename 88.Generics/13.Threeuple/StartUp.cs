namespace Threeuple
{
    public class StartUp
    {
        static void Main()
        {
            string[] names = Console.ReadLine().Split();

            string name = names[0] + " " + names[1];
            string address = names[2];
            string town = names[3];

            Threeuple<string, string, string> data = new(name, address, town);
            Console.WriteLine(data);


            string[] beer = Console.ReadLine().Split();

            name = beer[0];
            int beers = int.Parse(beer[1]);
            bool IsDrunk = (beer[2] == "drunk")  ?  true : false;

            Threeuple<string, int, bool> data1 = new(name, beers, IsDrunk);
            Console.WriteLine(data1);

            string[] bank = Console.ReadLine().Split();

            name = bank[0];
            double account = double.Parse(bank[1]);
            string bankName = bank[2];

            Threeuple<string, double, string> data2 = new(name, account, bankName);

            Console.WriteLine(data2);

        }
    }
}
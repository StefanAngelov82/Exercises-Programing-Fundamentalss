namespace GenericSwapMethodStrings
{
    public class StartUp
    {
        static void Main()
        {
            List<string> list = new List<string>();

            int N = int.Parse(Console.ReadLine());

            for (int i = 0; i < N; i++)
            {
                string element = Console.ReadLine();
                list.Add(element);
            }

            string command = Console.ReadLine();

            int index1 = int.Parse(command.Split()[0]);
            int index2 = int.Parse(command.Split()[1]);

            Swap(list, index1, index2);

            foreach (var element in list)
            {
                Console.WriteLine($"{element.GetType()}: {element}");
            }                        
        }

        static void Swap<T>(List<T> data, int index1, int index2)
        {
            T temp = data[index1];
            data[index1] = data[index2];
            data[index2] = temp;
        }
    }
}
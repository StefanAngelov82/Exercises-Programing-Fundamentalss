namespace GenericArrayCreator
{
    public class StartUp
    {
        static void Main()
        {
            
            double[] integers = ArrayCreator.Create(10, 33.01);

            for (int i = 0; i < integers.Length; i++)
            {
                Console.WriteLine(integers[i]);
            }

        }
    }
}
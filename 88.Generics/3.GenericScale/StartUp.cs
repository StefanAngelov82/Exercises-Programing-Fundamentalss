namespace GenericScale
{
    public class StartUp
    {
        static void Main(string[] args)
        {
            EqualityScale<int> current = new EqualityScale<int>(5, 6);

            Console.WriteLine(current.AreEqual());
        }
    }
}
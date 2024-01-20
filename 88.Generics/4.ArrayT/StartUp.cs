namespace ArrayT
{
    internal class StartUp
    {
        static void Main()
        {
            ObjectList<int> gg = new ObjectList<int>(5);

            gg.Add(199);
            gg.Add(166);
            Console.WriteLine(gg.GetData(0));
        }
    }
}
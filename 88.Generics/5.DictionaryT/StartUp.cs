namespace DictionaryT
{
    public class StartUp
    {
        static void Main(string[] args)
        {
            ObjectDictionary<string, int> dic = new ObjectDictionary<string, int>(5);

            dic.AddData("Pesho", 5);
            dic.AddData("Mimi", 6);

            Console.WriteLine(dic.GetData("Mimi"));
        }
    }
}
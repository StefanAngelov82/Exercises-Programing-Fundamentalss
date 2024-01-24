namespace NumbersEnumerator
{
    public class StartUp
    {
        static void Main()
        {
            NumbersEnumerable numb = new NumbersEnumerable();

            foreach (var item in  numb)
            {
                Console.WriteLine(item);
            }
           
        }
    }
}
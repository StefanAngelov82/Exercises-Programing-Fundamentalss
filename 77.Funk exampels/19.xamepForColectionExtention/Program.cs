namespace ExamepForColectionExtention
{
    internal class Program
    {
        static void Main(string[] args)
        {

            /// remove '-'
            String text = "--Text---";

            Console.WriteLine(text.TrimDashes());

            /// forEach HashSet

            HashSet<int> set = new HashSet<int>() { 1, 3, 4, 7};
            HashSet<string> set1 = new HashSet<string>() { "1", "2", "4"};

            set.ForEach1(x => Console.WriteLine((x + 1)));
            set1.ForEach1(x => Console.WriteLine((x + "&")));


            Console.WriteLine(string.Join("/", set));
        }
    }
}
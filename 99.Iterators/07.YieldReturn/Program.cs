using System.Collections;

namespace YieldReturn
{
    internal class Program
    {
        static void Main(string[] args)
        {
            MyEnunm list = new MyEnunm();

            foreach (var item in list)
            {
                Console.WriteLine(item);
            }


        }

        

    }

    class MyEnunm : IEnumerable<int>
    {
        public IEnumerator<int> GetEnumerator() => GenerateNumbers();       

        IEnumerator IEnumerable.GetEnumerator() => GenerateNumbers();
        

        public IEnumerator<int> GenerateNumbers()
        {
            yield return 1;
            yield return 5;
            yield return 9;
            yield return 10;
        }
    }
}
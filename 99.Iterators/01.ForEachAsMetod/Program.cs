namespace ForEachAsMetod
{
    internal class Program
    {
        static void Main(string[] args)
        {
            List<int> list = new List<int>() { 1, 2, 3};
            Action<int> callBack = x => Console.WriteLine(x);

           
            ForEach(callBack, list);

            


            void ForEach<T>(Action<T> callBack, IEnumerable<T> collection)
            {
                IEnumerator<T> enumerator = collection.GetEnumerator();

                while (enumerator.MoveNext())
                {
                    callBack(enumerator.Current);
                }
            }
        }

       
    }
}
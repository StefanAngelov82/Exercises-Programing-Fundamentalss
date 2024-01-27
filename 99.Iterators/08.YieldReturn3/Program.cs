using System.Collections;
using System.Net.WebSockets;

namespace YieldReturn3
{
    internal class Program
    {
        static void Main(string[] args)
        {
            List<int> data = new List<int>() {1, 3,5 }; 

            MyEnum My = new MyEnum(data);

            foreach (var item in My)
            {
                Console.WriteLine(item);
            }
        }
    }

    class MyEnum : IEnumerable<int>
    {
        private List<int> Data { get; set; }

        public MyEnum(List<int> data)
        {
            this.Data = data;
        }

        public IEnumerator<int> GetEnumerator() => GetEnumerator1(Data);

        IEnumerator IEnumerable.GetEnumerator() => GetEnumerator1(Data);

        public IEnumerator<int> GetEnumerator1(List<int> data)
        {
            foreach (var item in data)
            {
                yield return item;
            }
        }
    }

}
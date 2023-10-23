using System.Diagnostics;
using System.Text;

namespace test
{
    internal class Program
    {
        static void Main(string[] args)
        {
            string texts = "Maro";
            StringBuilder sb = new StringBuilder();
            StringBuilder sb1 = new StringBuilder();

            

            Stopwatch stopwatch = new Stopwatch();

            stopwatch.Start();

            

            char[] chars = texts.ToCharArray();

            Array.Reverse(chars);

            Console.WriteLine(new string(chars));

            stopwatch.Stop();

            Console.WriteLine($"First attempt : {stopwatch.Elapsed}");

            stopwatch.Reset();

            ///////////////////////////////////////////////////
            ///


            stopwatch.Start();



            for (int i = texts.Length - 1; i >= 0; i--)
            {
                sb.Append(texts[i]); 
            }

            Console.WriteLine(sb.ToString());


            stopwatch.Stop();

            Console.WriteLine($"First attempt1 : {stopwatch.Elapsed}");


            ///////////////////////////
            ///
            stopwatch.Reset();
            stopwatch.Start();

            texts = texts.Reverse().ToString();

            Console.WriteLine(texts);
            Console.WriteLine($"First attempt2 : {stopwatch.Elapsed}");


            //////////////////////
            ///
            stopwatch.Reset();
            stopwatch.Start();

            
        }
    }
}
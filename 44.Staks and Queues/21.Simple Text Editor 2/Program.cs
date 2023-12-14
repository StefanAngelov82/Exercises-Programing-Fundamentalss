using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace Simple_Text_Editor_2
{
    internal class Program
    {
        static void Main(string[] args)
        {
            int N = int.Parse(Console.ReadLine());

            StringBuilder sb = new StringBuilder();
            Stack<string> histotian = new Stack<string>();

            for (int i = 0; i < N; i++)
            {
                string[] inputArg = Console.ReadLine().Split();

                switch (inputArg[0])
                {
                    case "1":

                        histotian.Push(sb.ToString());
                        sb.Append(inputArg[1]);

                        break;
                    case "2":

                        histotian.Push(sb.ToString());

                        int elements = int.Parse(inputArg[1]);                        
                        sb.Remove(sb.Length - elements, elements);                        

                        break;
                    case "3":

                        int index = int.Parse(inputArg[1]);
                        Console.WriteLine(sb.ToString().ElementAt(index - 1));

                        break;
                    case "4":

                        sb.Clear();
                        sb.Append(histotian.Pop());

                        break;
                }
            }
        }
    }
}

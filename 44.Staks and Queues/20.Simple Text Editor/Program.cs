using System;
using System.Collections.Generic;
using System.Text;

namespace Simple_Text_Editor
{
    internal class Program
    {
        static void Main(string[] args)
        {
            int numberOperations = int.Parse(Console.ReadLine());

            StringBuilder sb = new StringBuilder();

            Stack<string> history = new Stack<string>();

            string input = String.Empty;
            sb.Append(input);           

            for (int i = 0; i < numberOperations; i++)
            {
                string[] inputArg = Console.ReadLine().Split();

                switch (inputArg[0])
                {
                    case "1":
                        history.Push(sb.ToString());

                        input = inputArg[1];
                        sb.Append(input);
                        break;

                    case "2":
                        int elements = int.Parse(inputArg[1]);
                        string currenText = sb.ToString();

                        history.Push(currenText);

                        currenText = currenText.Remove(currenText.Length - elements);

                        sb.Clear();
                        sb.Append(currenText);
                        break;

                    case "3":
                        int element = int.Parse(inputArg[1]);
                        string currentText = sb.ToString();

                        Console.WriteLine(currentText[element - 1]);

                        break;
                    case "4":
                        string oldText = history.Pop();
                        sb.Clear();
                        sb.Append(oldText);

                        break;
                }
            }


        }
    }
}

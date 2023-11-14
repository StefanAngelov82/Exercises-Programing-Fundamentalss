using System.Text;

namespace String_Explosion1
{
    internal class Program
    {
        static void Main(string[] args)
        {
            string text = Console.ReadLine();

            StringBuilder sb = new StringBuilder();

            int counter = 0;            

            for (int i = 0; i < text.Length; i++)
            {
                if (text[i] != '>' && counter == 0 )
                {
                    sb.Append(text[i]);
                }
                else if (text[i] == '>')
                {
                    if (counter != 0) counter--;

                    sb.Append(text[i]);
                    counter += int.Parse(text[i + 1].ToString());                    
                }                
                else
                {
                    counter--;
                }
            }

            Console.WriteLine(sb.ToString());
        }
    }
}
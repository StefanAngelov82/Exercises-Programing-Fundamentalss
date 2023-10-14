using System.IO;

namespace SteramForWrite
{
    internal class Program
    {
        static void Main(string[] args)
        {
            string textLocation = @"C:\Games\SoftUni\02.Checks\Files prossesing\WriteFile\bin\Debug\net6.0\text.txt";

            StreamWriter write = new StreamWriter(textLocation);

            write.WriteLine("Bonansa Ned");
            write.WriteLine("Mama mia");

            write.Close();

            //////////////////////////////////////
            using (StreamWriter write1 = new StreamWriter(textLocation ))
            {
                write1.WriteLine("Bonansa Ned");
                write1.WriteLine("Mama mia");
            }
            //////// za dobawqne na tekst Append()


            using (StreamWriter write2 = new StreamWriter(textLocation, append: true))
            {
                write2.WriteLine("BBaba");
                write2.WriteLine("Yaga");
            }
        }
    }
}
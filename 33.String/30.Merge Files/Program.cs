namespace Merge_Files
{
    internal class Program
    {
        static void Main(string[] args)
        {
            string[] text1 = File.ReadAllLines(@"../../../text1.txt");
            string[] text2 = File.ReadAllLines(@"../../../text2.txt");

            using (StreamWriter SW = new StreamWriter(@"../../../result.txt"))
            {
                for (int i = 0; i < Math.Min(text1.Length, text2.Length); i++)
                {
                    SW.WriteLine(text1[i]);
                    SW.WriteLine(text2[i]);
                }

                if (text1.Length > text2.Length)
                {
                    int start = text1.Length - (text1.Length - text2.Length);

                    for (int i = start; i < text1.Length; i++)
                    {
                        SW.WriteLine(text1[i]);
                    }
                }
            }
        }
    }
}
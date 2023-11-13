namespace String_Explosion
{
    internal class Program
    {
        static void Main(string[] args)
        {
            string[] text = Console.ReadLine().Split('>');

            int expotionStrenght = 0;
            int residulStrenght = 0;

            for (int i = 1; i < text.Length; i++)
            {
                expotionStrenght = (int)(text[i][0] - 48) + residulStrenght;

                residulStrenght = expotionStrenght - text[i].Length; 

                if (residulStrenght >= 0)
                {
                    text[i] = "";
                }
                else
                {
                    text[i] = text[i].Substring(expotionStrenght);
                    residulStrenght = 0;
                }
            }

            Console.WriteLine(string.Join(">", text));
        }
    }
}
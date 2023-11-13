using System.Runtime.CompilerServices;

namespace Valid_Usernames
{
    internal class Program
    {
        static void Main(string[] args)
        {
            string[] text = Console.ReadLine().Split(", ");

            foreach (var word in text)
            {
                bool isCorrect = true;                

                for (int i = 0; i < word.Length; i++)
                {
                    if (!(word[i] == '-' || word[i] == '_' || char.IsLetter(word[i]) || char.IsDigit(word[i])))
                    {
                        isCorrect = false;
                    }
                }

                if (isCorrect && (word.Length > 2 && word.Length < 17)) 
                    Console.WriteLine(word);
            }
        }
    }
}
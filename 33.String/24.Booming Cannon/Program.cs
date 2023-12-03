using System.Runtime.InteropServices;
using System.Text.RegularExpressions;

namespace Booming_Cannon
{
    internal class Program
    {
        static void Main(string[] args)
        {
            int[] info = Console.ReadLine()
                .Split()
                .Select(int.Parse)
                .ToArray();

            List<string> result = new List<string>();

            int distance = info[0];
            int damage = info[1];

            string topology = Console.ReadLine();

            string pattern = @"(?<=\\<<<)(?<target>.*?)(?=\\<<<|$)";

            foreach (Match match in Regex.Matches(topology, pattern))
            {
                string victome = (match.Groups["target"].Value).Substring(distance, damage);

                if (victome.Length != 0)
                {
                    result.Add(victome);
                }               
            }

            Console.WriteLine(string.Join("/\\", result));
        }
    }
}
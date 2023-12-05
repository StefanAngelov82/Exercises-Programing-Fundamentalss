using System.Text.RegularExpressions;

namespace Fish_Statistics
{
    
    internal class Program
    {
        public const int count = 1;

        static void Main(string[] args)
        {
            
            string observation = Console.ReadLine();

            List<Fish> data = new List<Fish>();

            string patternFish = @"(?<tail>[>]*)<(?<body>[\(]+)(?<status>[\'\-x])>";

            foreach (Match match in Regex.Matches(observation, patternFish))
            {
                int tailLenght = match.Groups["tail"].Value.Length;
                int bodyLenght = match.Groups["body"].Value.Length;
                string status  = match.Groups["status"].Value;
                string pattern = match.Groups[0].Value;

                if (bodyLenght > 0)
                {
                    Fish current = new Fish(tailLenght, bodyLenght, status, pattern);
                    data.Add(current);
                }                
            }
            if (data.Count == 0 )
            {
                Console.WriteLine("No fish found.");
            }
            else
            {
                int count = 1;
                foreach (var fish in data)
                {
                    Console.WriteLine($"Fish {count} : {fish}");
                    count++;
                }

            }
        }
    }
    class Fish
    {
        public int TailLengt { get; set; }
        public int BodyLength { get; set; }
        public string Status { get; set; }
        public string Pattern { get; set; }


        public Fish(int tailLenght, int bodylenght, string staus, string pattern)
        {
            this.TailLengt = tailLenght;
            this.BodyLength = bodylenght;
            this.Status = staus;
            Pattern = pattern;
        }

        public override string ToString()
        {
            string tailType;
            string bodyType;
            string status;

            if (this.TailLengt > 5)         tailType = "Long";           
            else if (this.TailLengt > 1)    tailType = "Medium";           
            else if (this.TailLengt == 1)   tailType = "Sort";           
            else                            tailType = "None";

            if (this.BodyLength > 10)       bodyType = "Long";
            else if (this.BodyLength > 5)   bodyType = "Medium";
            else                            bodyType = "Sort";

            if (this.Status == "\'")        status = "Awake";
            else if (this.Status == "-")    status = "Asleep";
            else                            status = "Dead";

            if (tailType != "None")
            {
                return $"{this.Pattern} \n" +
                   $"   Tail type: {tailType}  ({this.TailLengt * 2} cm) \n" +
                   $"   Body type: {bodyType} ({this.BodyLength * 2} cm) \n" +
                   $"   Status: {status}";
            }
            else
            {
                return $"{this.Pattern} \n" +
                   $"   Tail type: {tailType} \n" +
                   $"   Body type: {bodyType} ({this.BodyLength * 2} cm) \n" +
                   $"   Status: {status}";
            }

           
        }
    }
}
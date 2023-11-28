using System.Text.RegularExpressions;

namespace test
{
    internal class Program
    {
        static void Main(string[] args)
        {
            //string pattern = @"A\w+";
            //Regex matrix = new Regex(pattern);

            //Match ss = matrix.Match("Aleksis dude");

            //Console.WriteLine(ss.Value);


            /////////////////////////////////////////
            ///isMatch

            //string text = "Today is 2015-05-11";
            //string pattern = @"\d{4}-\d{2}-\d{2}";

            //Regex reg = new Regex(pattern);

            //bool isExist = reg.IsMatch(text);

            //Console.WriteLine(isExist);

            ////////////////////////////////
            ///Match

            //string text = "Nakov: 123";
            //string pattern = @"([A-Z][a-z]+): (\d+)";

            //Regex reg = new Regex(pattern);

            //Match match = reg.Match(text);

            //Console.WriteLine(match.Groups.Count); 
            //Console.WriteLine("Matched text: \"{0}\"", match.Groups[0]);
            //Console.WriteLine("Name: {0}", match.Groups[1]); // Nakov
            //Console.WriteLine("Number: {0}", match.Groups[2]); // 123
            //////////////////////////////////////////////////
            //////Matches
            ///

            //string text = "Nakov: 123, Branson: 456";
            //string pattern = @"([A-Z][a-z]+): (\d+)";

            //);

            //MatchCollection matches = reg.Matches(text);

            //Console.WriteLine($"Found {matches.Count} matches");

            //foreach (Match match in matches)
            //{
            //    Console.WriteLine($"Name : {match.Groups[1]}");
            //    Console.WriteLine($"Code : {match.Groups[2]}");
            //}
            /////////////////////////////////////////////////
            ////Matches with group names

            //string text = "Nakov: 123, Branson: 456, Stefan: 344";
            //string pattern = @"(?<Name>[A-Za-z]+): (?<Code>\d+)"; 

            //Regex reg = new Regex(pattern);

            //MatchCollection matches = reg.Matches(text);

            //Console.WriteLine($"found {matches.Count} matches");

            //foreach(Match match in matches)
            //{
            //    // Console.WriteLine($"{match.Groups[1].Name} : {match.Groups[1]}");
            //    // Console.WriteLine($"{match.Groups[2].Name} : {match.Groups[2]}");
            //    Console.WriteLine($"Name : {match.Groups["Name"]}");
            //    Console.WriteLine($"Code : {match.Groups["Code"]}");

            //}


            /////////////////////////////////////////
            ///////Replace
            ///

            //string text = "Nakov: 123, Branson: 456";
            //string pattern = @"\d{3}";
            //string replacement = "999";

            //Regex regex = new Regex(pattern);

            //string result = regex.Replace(text, replacement);

            //Console.WriteLine(result);


            ///////////////////////////////////////
            //////split
            ///
            //string text = "Nakov: 123, Branson: 456";
            //string pattern = @"\d{3}";
            //string replacement = "999";

            //Regex regex = new Regex(pattern);

            //string result = regex.Replace(text, replacement);

            //Console.WriteLine(result);
            ////////////////////////////////
            ///Split 
            //string text = "Petar||97456097||Yordan||84675984||Krustan";
            //string pattern = @"\|\|\d*\|\|";
            //string[] results = Regex.Split(text, pattern);
            //Console.WriteLine(string.Join(", ", results));

            string text = "13/Jul/1928, 01/Jan-1951";
            string pattern = @"(?<Day>\d{2})(?:\/|-)(?<Month>\w{3})(?:\/|-)(?<Year>\d{4})";

            Regex reg = new Regex(pattern);

            MatchCollection mm = reg.Matches(text);

            foreach (Match m in mm)
            {
                Console.Write($"{m.Groups[1].Name}: {m.Groups[1]}, ");
                Console.Write($"{m.Groups[2].Name}: {m.Groups["Month"]}, ");
                Console.WriteLine($"{m.Groups[3].Name}: {m.Groups[3].Value}");
            }


        }

    }
}
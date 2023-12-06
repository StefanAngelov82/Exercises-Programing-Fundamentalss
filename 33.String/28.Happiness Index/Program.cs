using System.Text.RegularExpressions;

namespace Happiness_Index
{
    internal class Program
    {
        static void Main(string[] args)
        {
            string input = Console.ReadLine();

            string positivePattern = @"(?<positive>[\(\*c\[][:|;]|[:|;][\)D\*\}\]])";
            string negativPattern = @"(?<positive>[\)D\]][:|;]|[:|;][\(\{\[c])";

            Regex regPositive  = new Regex(positivePattern);
            Regex regNegative = new Regex(negativPattern);

            int positiveCount = regPositive.Matches(input).Count();
            int negativeCount = regNegative.Matches(input).Count();

            double happinessIndex =(double) positiveCount / negativeCount;

            string happiness = String.Empty;

            if (happinessIndex >= 2)        happiness = ":D";
            else if (happinessIndex > 1)    happiness = ":)";
            else if (happinessIndex == 1)   happiness = ":|";
            else                            happiness = ":(";            

            Console.WriteLine($"Happiness index: {happinessIndex:F2} {happiness}");
            Console.WriteLine($"[Happy count: {positiveCount}, Sad count: {negativeCount}]");
        }
    }
}
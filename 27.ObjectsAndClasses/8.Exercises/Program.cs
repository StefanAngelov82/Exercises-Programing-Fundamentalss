namespace Exercises
{
    internal class Program
    {
        static void Main(string[] args)
        {
            List<Exercises> data = new List<Exercises>();

            string input = String.Empty;

            while ((input = Console.ReadLine()) !="go go go")
            {
                data.Add(Exercises.ParseData(input));
            }

            foreach (var exercises in data)
            {
                Console.WriteLine($"Exercises: {exercises.Topic}");
                Console.WriteLine($"Problems for exercises and homework for the “{exercises.CourseName}” course @ SoftUni.");
                Console.WriteLine($"Check your solutions here: {exercises.JudgeContestLink}.");

                int counter = 0;

                foreach (var problem in exercises.Problems)
                {
                    counter++;

                    Console.WriteLine($"{counter}. {problem}");
                }
            }
        }
        class Exercises
        {
            public string Topic { get; set; }
            public string CourseName { get; set; }
            public string JudgeContestLink { get; set; }
            public List<string> Problems { get; set; }


            public Exercises(string topic, string courseName, string judgeContestLink, List<string> problems)
            {
                Topic = topic;
                CourseName = courseName;
                JudgeContestLink = judgeContestLink;
                Problems = problems;
            }

            public static Exercises ParseData(string input)
            {
                string[] inputArgs = input
                    .Split(new string[] { " -> ", ", " }, StringSplitOptions.RemoveEmptyEntries);

                List<string> problems = inputArgs
                   .Skip(3)
                   .ToList();

                return new Exercises(inputArgs[0], inputArgs[1], inputArgs[2], problems); 

            }           
        }
    }
}
//ObjectsAndSimpleClasses -> ProgrammingFundamentalsExtended -> https://judge.softuni.bg/Contests/439 -> Exercises, OptimizedBankingSystem, Animals, Websites, Boxes, BoxIntersection, Messages
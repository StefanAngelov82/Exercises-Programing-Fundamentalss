namespace SoftuniEXam
{
    internal class Program
    {
        static void Main(string[] args)
        {
            List<Student> studentsData = new List<Student>();
            List<Language> examData = new List<Language>();

            string input = String.Empty;

            while ((input = Console.ReadLine()) != "exam finished")
            {
                string[] inputArg = input.Split("-", StringSplitOptions.RemoveEmptyEntries);

                if (inputArg.Length == 3 )
                {
                    string userName = inputArg[0];
                    string language = inputArg[1];
                    int points = int.Parse(inputArg[2]);

                    AddStudentData(studentsData, userName, points);
                    AddExamData(examData, language);
                }
                else                
                    RemoveStudent(studentsData, inputArg);
               
            }

            PrintData(studentsData, examData);
        }

        static void RemoveStudent(List<Student> studentsData, string[] inputArg)
        {
            Func<string, Student> func = (x) => studentsData.Find(x => x.Name == inputArg[0]);

            studentsData.Remove(func(inputArg[0]));
        }

        static void PrintData(List<Student> studentsData, List<Language> examData)
        {
            Console.WriteLine("Results:");

            studentsData.OrderByDescending(x => x.Points)
                .ThenBy(x => x.Name)
                .ToList()
                .ForEach(x => Console.WriteLine($"{x.Name} | {x.Points}"));

            Console.WriteLine("Submissions:");

            examData.OrderByDescending(x => x.Submission)
                .ThenBy(x => x.Name)
                .ToList()
                .ForEach(x => Console.WriteLine($"{x.Name} - {x.Submission}"));
        }

        static void AddExamData(List<Language> examData, string language)
        {
            Language? current = examData.FirstOrDefault(x => x.Name == language);

            if (current == null)
                examData.Add(new Language(language, 1));

            else
                 current.Submission++;
        }

        static void AddStudentData(List<Student> studentsData, string userName, int points)
        {
            Student? current = studentsData.FirstOrDefault(x => x.Name == userName);

            if (current == null)
                studentsData.Add(new Student(userName, points));

            else
                if(points > current.Points)
                    current.Points = points;
        }   
    }
    class Student
    {
        public string Name { get; set; }
        public int Points { get; set; }

        public Student(string name, int points)
        {
            this.Name = name;
            this.Points = points;
        }        
    }

    class Language
    {
        public string Name { get; set; }
        public int Submission { get; set; }

        public Language(string name, int submission)
        {
            this.Name = name;
            this.Submission = submission;
        }      
    }
}
using GroupBYExample;

namespace JOINEXAMPLE______
{
    

    internal class Program
    {
        static void Main(string[] args)
        {
            List<Student> students = new List<Student>();
            List<Course> courses = new List<Course>();

            Course course = new(1,"C");
            Course course2 = new(2,"C++");
            Course course3 = new(3,"Java");
            Course course4 = new(4,"JS");

            courses.Add(course);
            courses.Add(course2);
            courses.Add(course3);
            courses.Add(course4);

            Student student = new Student("Stefan", "Angelov", 42, 1);
            Student student1 = new Student("Naum", "Pertov", 43, 1);
            Student student2 = new Student("Kiril", "Zamanov", 29,2);
            Student student3 = new Student("Kiril", "Iliev", 39,3);
            Student student4 = new Student("Kiril", "Asenov", 49, 4);

            students.Add(student1);
            students.Add(student2);
            students.Add(student3);
            students.Add(student4);
            students.Add(student);

            Func<Student, Course, REsult> MixFunction =
                (st, c) => new REsult((st.FirstName + " " + st.LastName), c.CourseName);

            var StudentInCourse = students
                .Join(
                    courses,
                    st => st.CourseID,
                    c => c.CourseID,
                    MixFunction
                    ); 


            foreach (var st in StudentInCourse)
            {
                Console.WriteLine(st.ToString());
            }
        }  
       
    }

    public class REsult
    {
        public REsult(string studentName, string visitedCourse)
        {
            StudentName = studentName;
            VisitedCourse = visitedCourse;
        }

        public string StudentName { get; set; }
        public string VisitedCourse { get; set; }

        public override string ToString()
        {
            return $"{StudentName} - {VisitedCourse}";
        }
    }
}
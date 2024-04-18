using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace GroupBYExample
{
    public class Student
    {
        public Student(string firstName, string lastName, int age, int courseID)
        {
            FirstName = firstName;
            LastName = lastName;
            Age = age;
            CourseID = courseID;
        }

        public string FirstName { get; set; }
        public string LastName { get; set; }
        public int Age { get; set; }
        public int CourseID { get; set; }
    }
}

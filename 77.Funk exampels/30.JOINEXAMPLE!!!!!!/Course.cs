using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace JOINEXAMPLE______
{
    public class Course
    {
        public Course(int courseID, string courseName)
        {
            CourseID = courseID;
            CourseName = courseName;
        }

        public int CourseID { get; set; }
        public string CourseName { get; set; }

    }
}

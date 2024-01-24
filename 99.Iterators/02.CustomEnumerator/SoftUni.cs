using System;
using System.Collections;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace CustomEnumerator
{
    public class SoftUni : IEnumerable<Students>
    {

        private List<Students> students;

        public SoftUni()
        {
            this.students = new List<Students>();
        }

        public void AddStudent(Students current)
        {
            students.Add(current);
        }

        public IEnumerator<Students> GetEnumerator()
        {
            return new StudentsEnumerator(students);
        }

        IEnumerator IEnumerable.GetEnumerator()
        {
            return GetEnumerator();
        }
    } 
}

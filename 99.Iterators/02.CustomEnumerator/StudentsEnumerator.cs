using System;
using System.Collections;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace CustomEnumerator
{
    public class StudentsEnumerator : IEnumerator<Students>
    {
        private int index = -1;
        private List<Students> students;

        public StudentsEnumerator(List<Students> students)
        {
            this.students = students;
        }

        public Students Current => students[index];

        object IEnumerator.Current => Current;
              

        public bool MoveNext()
        {
            index++;
            return index < this.students.Count;
        }

        public void Reset()
        {
            index = -1;
        } 
        public void Dispose()
        {
            
        }
    }
}

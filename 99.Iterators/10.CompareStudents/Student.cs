using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace CompareStudents
{
    internal class Student : IComparable<Student>, IComparable<int>
    {
        public Student(double averageScore, string name)
        {
            this.averageScore = averageScore;
            this.Name = name;
        }

        public double averageScore { get; set; }
        public string Name { get; set; }

        public int CompareTo(Student? other)
        {
            if (this.averageScore < other.averageScore)
            {
                return -1;
            }
            else if (this.averageScore == other.averageScore)
            {
                return this.Name.CompareTo(other.Name);
            }
            else
            {
                return 1;
            }
        }

        public int CompareTo(int score)
        {
            if (this.averageScore < score)
            {
                return -1;
            }
            else if (this.averageScore == score)
            {
                return 0;
            }
            else
            {
                return 1;
            }
        }
    }
}

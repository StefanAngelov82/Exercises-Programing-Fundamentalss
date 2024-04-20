namespace P03_StudentSystem.Students
{
    using System;
    using System.Collections.Generic;

    public class Student
    {
        public Student(string name, int age, double grade)
        {
            Name = name;
            Age = age;
            Grade = grade;
        }
        public double Grade { get; private set; }
        public int Age { get; private set; }
        public string Name { get; private set; }

        public override string ToString()
        {
            string studentInfo = $"{Name} is {Age} years old.";

            if (Grade >= 5.00)
            {
                studentInfo += " Excellent student.";
            }
            else if (Grade < 5.00 && Grade >= 3.50)
            {
                studentInfo += " Average student.";
            }
            else
            {
                studentInfo += " Very nice person.";
            }


            return studentInfo;
        }

    }
}
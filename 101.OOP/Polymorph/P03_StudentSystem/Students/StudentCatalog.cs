using System;
using System.Collections.Generic;
using System.Text;

namespace P03_StudentSystem.Students
{
    public class StudentSystem
    {
        private Dictionary<string, Student> studentCatalog;

        public StudentSystem()
        {
            studentCatalog = new Dictionary<string, Student>();
        }

        public void AddStudent(string name, int age, double grade)
        {
            if (!studentCatalog.ContainsKey(name))
            {
                var student = new Student(name, age, grade);
                studentCatalog[name] = student;
            }
        }

        public Student GetStudent(string name)
        {
            if (!studentCatalog.ContainsKey(name))
            {
                throw new InvalidOperationException($"We do not have this name - {name} in our database");
            }
            return studentCatalog[name];
        }
    }
}

using P03_StudentSystem.Commands;
using P03_StudentSystem.Data.Interface;
using P03_StudentSystem.Students;
using System;
using System.Collections.Generic;
using System.Text;

namespace P03_StudentSystem
{
    public class Engine
    {
        private CommandParser commandParser;
        private StudentSystem studentSystem;
        private IDataReader reader;
        private IDataWrither writher;

        public Engine(CommandParser commandParser, StudentSystem studentSystem, IDataReader reader, IDataWrither writher)
        {
            this.commandParser = commandParser;
            this.studentSystem = studentSystem;
            this.reader = reader;
            this.writher = writher;
        }

        public void Run()
        {
            while (true)
            {
                try
                {
                    Command command = commandParser.Parse(reader.Read());

                    if (command.Name == "Create")
                    {
                        string name = command.Arguments[0];
                        int age = int.Parse(command.Arguments[1]);
                        double grade = double.Parse(command.Arguments[2]);

                        studentSystem.AddStudent(name, age, grade);
                    }
                    else if (command.Name == "Show")
                    {
                        string name = command.Arguments[0];

                        Student student = studentSystem.GetStudent(name);
                        writher.Writ(student.ToString());
                    }
                    else if (command.Name == "Exit")
                        break;
                }
                catch (Exception ex)
                {

                    Console.WriteLine(ex.Message);
                }

            }
        }
    }
}

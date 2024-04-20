using System;
using System.Data;
using P03_StudentSystem.Commands;
using P03_StudentSystem.Data;
using P03_StudentSystem.Students;

namespace P03_StudentSystem
{
    public class StartUp
    {
        public static void Main()
        {
            CommandParser commandParser = new CommandParser();
            StudentSystem studentSystem = new StudentSystem();
            var dataReader = new DataReader();
            var dataWriter = new DataWriter();


            Engine engine = new Engine(commandParser, studentSystem, dataReader, dataWriter);

            engine.Run();
            
        }
    }
}

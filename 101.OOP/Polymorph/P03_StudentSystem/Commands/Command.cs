using System;
using System.Collections.Generic;
using System.Text;

namespace P03_StudentSystem.Commands
{
    public class Command
    {
        public Command(string name, string[] arguments)
        {
            Name = name;
            Arguments = arguments;
        }

        public string Name { get; set; }
        public string[] Arguments { get; set; }
    }
}

using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace P03_StudentSystem.Commands
{
    public class CommandParser
    {
        public Command Parse(string command)
        {
            string[] parts = command.Split();

            return new Command(parts[0], parts.Skip(1).ToArray());
        }
    }
}

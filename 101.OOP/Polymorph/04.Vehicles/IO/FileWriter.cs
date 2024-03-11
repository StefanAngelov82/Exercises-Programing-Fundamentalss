using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Vehicles.IO.Interface;

namespace Vehicles.IO
{
    public class FileWriter : IWriter
    {
        public void WriteLine(string line)
        {
            string filePath = "../../../text.txt";

            using  StreamWriter writer = new StreamWriter(filePath, true);

            writer.WriteLine(line);
        }
    }
}

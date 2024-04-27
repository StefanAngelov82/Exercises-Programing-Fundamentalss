using Football_Team_Generator.IO.Interface;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Football_Team_Generator.IO
{
    public class Writer : IWriter
    {
        public void Write(object text) 
            => Console.WriteLine(text);
        
    }
}

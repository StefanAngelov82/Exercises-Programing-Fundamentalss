using System;
using System.Collections.Generic;
using System.Text;

namespace Military_Elite2.IO
{
    public class Reader : IReader
    {
        public string Read() 
            => Console.ReadLine();
        
    }
}

using System;
using System.Collections.Generic;
using System.Text;

namespace Military_Elite2.IO
{
    public class Writer : IWriter
    {
        public void Write(object obj)
            => Console.WriteLine(obj.ToString()); 
        
    }
}

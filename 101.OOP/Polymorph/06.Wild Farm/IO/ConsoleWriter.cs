﻿using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Wild_Farm.IO.Interface;

namespace Wild_Farm.IO
{
    public class ConsoleWriter : IWriter
    {
        public void WriteLine(object obj)
        {
             Console.WriteLine(obj);
        }
    }
}

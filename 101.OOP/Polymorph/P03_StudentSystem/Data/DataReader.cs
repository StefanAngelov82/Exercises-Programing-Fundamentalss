using P03_StudentSystem.Data.Interface;
using System;
using System.Collections.Generic;
using System.Text;

namespace P03_StudentSystem.Data
{
    public class DataReader : IDataReader
    {
        public string Read()
        {
           return Console.ReadLine();
        }
    }
}

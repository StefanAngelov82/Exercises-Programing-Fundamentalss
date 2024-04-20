using System;
using System.Collections.Generic;
using System.Text;
using P03_StudentSystem.Data.Interface;

namespace P03_StudentSystem.Data
{
    public class DataWriter : IDataWrither
    {
        public void Writ(object obj)
        {
            Console.WriteLine(obj);
        }
    }
}

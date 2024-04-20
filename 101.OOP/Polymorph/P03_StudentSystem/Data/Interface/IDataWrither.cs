using System;
using System.Collections.Generic;
using System.Text;
using System.Threading.Tasks.Dataflow;

namespace P03_StudentSystem.Data.Interface
{
    public interface IDataWrither
    {
        void Writ(object obj);
    }
}

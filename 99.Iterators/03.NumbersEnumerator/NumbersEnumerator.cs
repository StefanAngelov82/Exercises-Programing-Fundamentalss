using System;
using System.Collections;
using System.Collections.Generic;
using System.Linq;
using System.Linq.Expressions;
using System.Text;
using System.Threading.Tasks;

namespace NumbersEnumerator
{
    public class NumbersEnumerator : IEnumerator<int>
    {

        private int element = 0;

        public int Current => element;

        object IEnumerator.Current => Current;

        public void Dispose()
        {
           
        }

        public bool MoveNext()
        {
            element++;
            return true;    
        }

        public void Reset()
        {
            throw new NotImplementedException();
        }
    }
}

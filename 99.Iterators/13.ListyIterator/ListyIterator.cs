using System;
using System.Collections;
using System.Collections.Generic;
using System.Data;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ListyIterator
{
    public class ListyIterator<T> : IEnumerable<T>     
        {
        private List<T> values;
        private int index = 0;

        public ListyIterator(List<T> values)
        {
            this.values = values;
        }

        public bool Move()
        {
            if (index < values.Count - 1)
            {
                index++;
                return true;
            }
            return false;
        }

        public bool HasNext()
        {
            return index + 1 < values.Count;
        }

        public void Print()
        {
            if (values.Count == 0)
            {
                throw new InvalidOperationException("Invalid Operation!");                
            }
            else
            {
                Console.WriteLine(values[index]);
            }
        }      

        public IEnumerator<T> GetEnumerator()
        {
            foreach (var item in values)
            {
                yield return item;
            }
        }

        IEnumerator IEnumerable.GetEnumerator()
        {
            return GetEnumerator();
        }
    }
}

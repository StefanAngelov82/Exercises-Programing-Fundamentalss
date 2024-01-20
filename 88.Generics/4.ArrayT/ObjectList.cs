using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ArrayT
{
    public class ObjectList<T>
    {
        private int index = 0;
        public T[] Data { get; set; }
        

        public ObjectList(int capacity)
        {
            this.Data = new T[capacity];
        }

        public void Add(T item)
        {
            this.Data[index] = item;
            index++;
        }

        public T GetData(int index)
        {
            return this.Data[index];
        }
    }
}

using System;
using System.Collections;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Stack
{
    public class CustomStack<T> : IEnumerable<T>
    {        
        private T[] data = new T[0];        

        public void Push(T[] data)
        {
            int addIndex = data.Length;
            int baseIndex = this.data.Length;

            int newIndex = addIndex + baseIndex;

            T[] newData = new T[newIndex];

            newData = this.data.Concat(data).ToArray();           
            this.data = newData;
        }

        public void Pop()
        {
            if (this.data.Length == 0)
            {
                Console.WriteLine("No elements");
            }
            else
            {

                T[] newData = new T[this.data.Length - 1];
                newData = this.data[0..(this.data.Length - 1)];
                this.data = newData;
            }
        }

        public IEnumerator<T> GetEnumerator()
        {
            for (int i = 0; i < 2; i++)
            {
                for (int j = data.Length - 1; j >= 0; j--)
                {
                    yield return data[j];
                }
            }
            
        }

        IEnumerator IEnumerable.GetEnumerator() => GetEnumerator();
        
    }
}

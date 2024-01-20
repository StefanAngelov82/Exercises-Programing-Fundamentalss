using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Xml.Linq;

namespace BoxOfT
{
    public class Box<T>
    {
        public Stack<T> Items { get; set; }
        public int Count { get => Items.Count;}

        public Box()
        {
            this.Items = new Stack<T>();
        }

        public void Add(T element)
        {
            Items.Push(element);
        }

        public T Remove()
        {
            return Items.Pop();
        }
    }
}

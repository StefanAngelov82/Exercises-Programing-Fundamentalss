using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace GenericBoxofString
{
    public class Box<T>
    {

        public T Data { get; set; }

        public Box(T data)
        {
            this.Data = data;
        }

        public override string ToString()
        {
            return $"{ typeof(T).FullName}: {Data.ToString()} ";
        }
    }
}

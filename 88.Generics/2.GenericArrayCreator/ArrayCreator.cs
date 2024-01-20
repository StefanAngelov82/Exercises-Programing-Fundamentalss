using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace GenericArrayCreator
{
    public class ArrayCreator
    {     
        public static T[] Create<T>(int length, T item)
        {
            T[] array  = new T[length];

            return array =  array.Select(x => x = item).ToArray();            
        }
    }
}

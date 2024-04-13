using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ExamepForColectionExtention
{
    public static class CollectionExtension
    {

        public static string TrimDashes(this string input)
            =>  input.Trim('-');

        public static IEnumerable<T> ForEach1<T>(this IEnumerable<T>hashSet, Action<T> action)
        {
            foreach (var item in hashSet)
            {
                action(item);
            }

            return hashSet;
        }
       
    }
}

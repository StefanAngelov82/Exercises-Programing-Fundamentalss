using System;
using System.Collections;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Library
{
    public class LibraryA : IEnumerable<Book>
    {
        private List<Book> Books;

        public LibraryA(params Book[] books)
        {
            this.Books = new List<Book>(books);
        }

        public IEnumerator<Book> GetEnumerator() => GetEnumerator1(Books);

        IEnumerator IEnumerable.GetEnumerator() => GetEnumerator1(Books);
        

        static IEnumerator<Book> GetEnumerator1(List<Book> books)
        {
            foreach (var book in books)
            {
                yield return book; 
            }
        }
        
    }
}

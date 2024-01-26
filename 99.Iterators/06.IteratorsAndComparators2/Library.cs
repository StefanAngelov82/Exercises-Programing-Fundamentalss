using System;
using System.Collections;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace IteratorsAndComparators
{
    public class Library : IEnumerable<Book>
    {
        private List<Book> Books; 

        public Library(params Book[] books)
        {
            this.Books = new List<Book>(books);
        }

        public IEnumerator<Book> GetEnumerator()
        {
            return new LibraryIterator(Books);
        }

        IEnumerator IEnumerable.GetEnumerator()
        {
            return GetEnumerator();
        }

        class LibraryIterator : IEnumerator<Book>
        {

            private int index = -1;
            private List<Book> copyBooks;

            public LibraryIterator(List<Book> books)
            {
                this.copyBooks = books;
            }

            public Book Current => copyBooks[index];

            object IEnumerator.Current => Current;

            public void Dispose()
            {
                
            }

            public bool MoveNext()
            {
                index++;
                return index < copyBooks.Count;
            }

            public void Reset()
            {
                 index = -1;
            }
        }
    }
}

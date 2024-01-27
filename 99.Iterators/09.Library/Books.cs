using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Library
{
    public class Book
    {
        public string Title { get; set; }
        public int Years { get; set; }
        public List<string> Authors { get; set; }

        public Book(string title, int years, params string[] authors)
        {
            this.Title = title;
            this.Years = years;
            this.Authors = authors.ToList();
        }
    }
}

using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DefiningClasses
{
    public class Family
    {
        public List<Person> Collection { get; set; }

        public Family()
        {
            this.Collection = new List<Person>();
        }

        public void AddMember(Person p)
        {
            this.Collection.Add(p);
        }

        public Person GetOldestMember()
        {
            return this.Collection.OrderByDescending(x => x.Age).First();
        }
    }
}

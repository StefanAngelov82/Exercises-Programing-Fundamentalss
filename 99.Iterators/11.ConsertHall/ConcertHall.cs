using ConcertHall;
using System;
using System.Collections;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ConcertHall
{
    public class ConcertHall : IEnumerable<int>
    {
        private List<int> seats;

        public ConcertHall(List<int> seats)
        {
            this.seats = seats;
        }

        // public IEnumerator<int> GetEnumerator() => new HallEnumerator(this.seats);     
        public IEnumerator<int> GetEnumerator() 
        {
            for (int i = seats.Count - 1; i >= 0; i--)
            {
                yield return seats[i];
            }
        }     

        IEnumerator IEnumerable.GetEnumerator() => GetEnumerator();
    }
}

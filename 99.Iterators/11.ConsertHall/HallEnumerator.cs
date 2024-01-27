using System;
using System.Collections;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ConcertHall
{
    public class HallEnumerator : IEnumerator<int>
    {
        private int index = -1;
        private List<int> seats;

        public HallEnumerator(List<int> seats)
        {
            this.seats = seats;
        }

        public int Current => seats[index];

        object IEnumerator.Current => Current;

        public void Dispose()
        {            
        }

        public bool MoveNext()
        {
            index++;
            return index < seats.Count;
        }

        public void Reset()
        {
            index = -1;
        }
    }
}

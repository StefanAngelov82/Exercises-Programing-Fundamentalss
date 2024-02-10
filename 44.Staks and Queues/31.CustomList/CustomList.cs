using System;
using System.Collections.Generic;
using System.Data;
using System.Diagnostics.Metrics;
using System.Linq;
using System.Linq.Expressions;
using System.Reflection;
using System.Reflection.Metadata;
using System.Text;
using System.Threading.Tasks;

namespace CustomListZZZ
{
    public class CustomList
    {
        private const int InitialCapacity = 2;

        private int[] items;

        public CustomList()
        {
            items = new int[InitialCapacity];
        }

        public int Count { get; private set; }
        public int this[int index]
        {
            get
            {
                ThrowExceptionIfIndexOutOfRange(index);
                return items[index];
            }
            set
            {
                ThrowExceptionIfIndexOutOfRange(index);
                items[index] = value;
            }
        }             



        public void Add(int item)
        {
            if (Count == items.Length)            
                Resize();           

            items[Count] = item;
            Count++;
        }    

        public void InsertAt(int index, int item)
        {
            ThrowExceptionIfIndexOutOfRange(index);

            ShiftRight(index, item);
        }       

        public int RemoveAt(int index)
        {
            ThrowExceptionIfIndexOutOfRange(index);

            int removedItem = items[index];

            SiftLeft(index);            

            return removedItem;
        }       

        public void Swap(int index1, int index2)
        {
            ThrowExceptionIfIndexOutOfRange(index1);
            ThrowExceptionIfIndexOutOfRange(index2);

            (items[index1], items[index2]) = (items[index2], items[index1]);
        }
        public bool Contains(int item)
        {
            foreach (int element in items)
            {
                if (element ==  item)                
                    return true;                                           
            }

            return false;
        }



        private void Resize()
        {
            int[] newArr = new int[items.Length * 2];

            items.CopyTo(newArr, 0);
            items = newArr;
        }

        private void ThrowExceptionIfIndexOutOfRange(int index)
        {
            if (index < 0 || index >= Count)
            {
                throw new IndexOutOfRangeException("Index is invalid");
            }

        }

        private void SiftLeft(int index)
        {
            for (int i = index; i < Count - 1; i++)
            {
                items[i] = items[i + 1];
            }

            Count--;

            if (Count * 4 <= items.Length)           
                Shrink();            
        }

        private void Shrink()
        {
            int[] temp = new int[items.Length / 2];

            items.CopyTo(temp, 0);
            
            items = temp;
        }
        private void ShiftRight(int index, int item)
        {
            if (Count == items.Length)
                Resize();
           
            for (int i = Count - 1; i >= index; i--)
            {
                items[i + 1] = items[i]; 
            }

            items[index] = item;
            Count++;
        }
    }
}

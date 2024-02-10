using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace CustomDoublyLinkedList
{
    public class DoublyLinkedList
    {
        public ListNode Head { get; set; }
        public ListNode Tail { get; set; }

        public int Count { get; set; }

        public void AddLast(int value)
        {
            ListNode newNode = new ListNode(value);

            Count++;

            if (Head == null)
            {
                Head = newNode;
                Tail = newNode;
                return;
            }

            newNode.Previous = Tail;
            Tail.Next = newNode;
            Tail = newNode;
        }
        public void AddFirst(int value)
        {
            ListNode newNode = new ListNode(value);

            Count++;

            if (Head == null)
            {
                Head = newNode;
                Tail = newNode;
                return;
            }

            newNode.Next = Head;
            Head.Previous = newNode;
            Head = newNode;
        }

        public void RemoveFirst()
        {
            ListNode newHead = Head.Next;

            Count--;

            if (newHead == null)
            {
                Head = null;
                Tail = null;
                return;
            }

            newHead.Previous = null;
            Head.Next = null;
            Head = newHead;
        }

        public void RemoveLast()
        {
            ListNode newTail = Tail.Previous;

            Count--;

            if (newTail == null)
            {
                Head = null;
                Tail = null;
                return;
            }

            newTail.Next = null;
            Tail.Previous = null;
            Tail = newTail;
        }

        public void ForEach(Action<int> callBack)
        {
            ListNode node = Head;

            while (node != null)
            {
                callBack(node.Value);
                node = node.Next;
            }
        }

        public int[] ToArray()
        {
            int[] array = new int[Count];
            int index = 0;

            ListNode node = Head;

            while(node != null)
            {
                array[index++] = node.Value;
                node = node.Next;
            }

            return array;
        }
    }
}


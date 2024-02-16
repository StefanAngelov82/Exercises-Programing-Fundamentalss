
using CustomDoublyLinkedList;
using System.Collections.Generic;
using System.Threading.Channels;

DoublyLinkedList listS =  new DoublyLinkedList();

listS.AddLast(1);
listS.AddLast(2);   
listS.AddLast(3);
listS.AddLast(4);
listS.AddLast(5);
listS.AddLast(6);

listS.ForEach
    ((x) =>

    Console.WriteLine(x)

    );

 int[] arr= listS.ToArray();

Console.WriteLine(string.Join(", ", arr));
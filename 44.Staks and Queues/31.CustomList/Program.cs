
using CustomListZZZ;
using System;

CustomList list = new CustomList();

list.Add(100);
list.Add(200);
list.Add(300);
list.Add(400);
list.Add(500);

list[2] = 700;

Console.WriteLine(list[0]);
Console.WriteLine(list[1]);
Console.WriteLine(list[2]);
Console.WriteLine(list[3]);
Console.WriteLine(list[4]);
Console.WriteLine();

//Console.WriteLine();
//Console.WriteLine(list.Count);

list.RemoveAt(2);

Console.WriteLine(list[0]);
Console.WriteLine(list[1]);
Console.WriteLine(list[2]);
Console.WriteLine(list[3]);
Console.WriteLine();


list.InsertAt(2, 300);

Console.WriteLine(list[0]);
Console.WriteLine(list[1]);
Console.WriteLine(list[2]);
Console.WriteLine(list[3]);
Console.WriteLine(list[4]);


Console.WriteLine();

Console.WriteLine(list.Contains(100));
Console.WriteLine(list.Contains(900));

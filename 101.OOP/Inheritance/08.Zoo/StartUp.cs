using System;

namespace Zoo
{
    public class StartUp
    {
        public static void Main(string[] args)
        {
            string name1  = Console.ReadLine();
            string name2  = Console.ReadLine();

           
            Reptile r1 = new Reptile(name2);
            //Snake s1 = new Snake(name);

            Console.WriteLine(r1.Name);
        }
    }
}
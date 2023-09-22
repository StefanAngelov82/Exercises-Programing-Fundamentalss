using System.ComponentModel;

namespace Rectangle_Position
{
    internal class Program
    {
        static void Main(string[] args)
        {
            Rectangle first = Rectangle.ParrsePoints(Console.ReadLine());
            Rectangle second = Rectangle.ParrsePoints(Console.ReadLine());

            Console.WriteLine(first.IsInside(second) ? "Inside" : "Not Inside");
        }
    }
    class Rectangle
    {
        public int Left { get; set; }
        public int Top { get; set; }
        public int Width { get; set; }
        public int Height { get; set; }

        public int Bottom
        {
            get
            {
                return Top + Height;
            }
        }

        public int Right
        {
            get
            {
                return Left + Width;
            }
        }
       

        public Rectangle(int left, int top, int width, int height)
        {
            Left = left;
            Top = top;
            Width = width; 
            Height = height;            
        }
        

        public static Rectangle ParrsePoints(string input)
        {
            int[] inputArg = input.Split(' ').Select(int.Parse).ToArray();

            return new Rectangle (inputArg[0], inputArg[1], inputArg[2], inputArg[3]);
        } 

        public bool IsInside (Rectangle other)
        {
            return this.Top >= other.Top && this.Left >= other.Left &&
                   this.Bottom <= other.Bottom && this.Right <= other.Right;
        }
    }
}
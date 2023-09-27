using System.ComponentModel;
using System.Reflection.Metadata;

namespace Boxes
{
    internal class Program
    {
        static void Main(string[] args)
        {
           List<Box> boxes = new List<Box>();

            string input = String.Empty;

            while ((input = Console.ReadLine()) != "end")
            {
                Point upperLeft = Point.PointParse(input, 1);
                Point upperRight = Point.PointParse(input, 2);
                Point bottomLeft = Point.PointParse(input, 3);
                Point bottomRigh = Point.PointParse(input, 4);

                Box currentBox = new Box(upperLeft, upperRight, bottomLeft, bottomRigh);
                               
                boxes.Add(currentBox);
                
            }

            foreach (Box boxx in boxes)
            {
                Console.WriteLine($"Box: {boxx.Width}, {boxx.Height}");
                Console.WriteLine($"Perimeter: {boxx.Perimeter}");
                Console.WriteLine($"Area: {boxx.Area}");
            }
        }
        class Box
        {
            public Point UpperLeft { get; set; }
            public Point UpperRight { get; set; }
            public Point BottomLeft { get; set; }
            public Point BottomRigh { get; set; }

            public double Width { get { return Point.CalculateDistance(UpperLeft, UpperRight); } }
            public double Height { get { return Point.CalculateDistance(UpperLeft, BottomLeft); } }

            public double Perimeter { get { return Box.CalculatePerimeter(Width, Height); } }
            public double Area { get { return Box.CalculateArea(Width, Height); } }

            public Box(Point upperLeft, Point upperRight, Point bottomLeft, Point bottomRigh)
            {
                UpperLeft = upperLeft;
                UpperRight = upperRight;
                BottomLeft = bottomLeft;
                BottomRigh = bottomRigh;
            }

            public static double CalculatePerimeter(double width, double height)
            {               
                return (2 * width  + 2 * height); 
            }
            public static double CalculateArea(double width, double height)
            {
                return width * height;
            }
        }
        class Point
        {
            public int X { get; set; }
            public int Y { get; set; }

            public Point(int xcoordinate, int ycoordinate)
            {
                X = xcoordinate;
                Y = ycoordinate;
            }

            static

            public double CalculateDistance(Point point1, Point point2)
            {
                int side1 = Math.Abs(point1.X - point2.X);
                int side2 = Math.Abs(point1.Y - point2.Y);

                double distance;

                return  distance = Math.Sqrt(side1 * side1 + side2 * side2);                
            }
            public static Point PointParse(string input, int pointCount)
            {
                int[] inputArg = input
                                .Split(new string[] { ":", " | " }, StringSplitOptions.RemoveEmptyEntries)
                                .Select(int.Parse)
                                .ToArray();

                if (pointCount == 1)        return new Point(inputArg[0], inputArg[1]);
                else if (pointCount == 2)   return new Point(inputArg[2], inputArg[3]);
                else if (pointCount == 3)   return new Point(inputArg[4], inputArg[5]);
                else                        return new Point(inputArg[6], inputArg[7]);
            }
            


        }


    }
}
namespace Distance_Between_Points
{
    internal class Program
    {
        static void Main(string[] args)
        {
            Point point1 = ReadPoint(Console.ReadLine());
            Point point2 = ReadPoint(Console.ReadLine());

            CalculateDistance(point1, point2);
        }

        private static void CalculateDistance(Point point1, Point point2)
        {
            int side1 = Math.Abs(point1.X - point2.X);
            int side2 = Math.Abs(point1.Y - point2.Y);

            double distance = Math.Sqrt(side1 * side1 + side2 * side2);
            Console.WriteLine($"{distance:F3}");
        }

        private static Point ReadPoint(string input)
        {
            int[] inputArg = input.Split(' ').Select(int.Parse).ToArray();

            return  new Point(inputArg[0], inputArg[1]);
        }
    }
    class Point
    {
        public int X { get; set; }
        public int Y { get; set; }

        public Point(int Xcoordinate, int Ycoordinate)
        {
            X = Xcoordinate;
            Y = Ycoordinate;            
        }
    }
}
namespace Closest_Two_Points
{
    internal class Program
    {
        static void Main(string[] args)
        {
            int count = int.Parse(Console.ReadLine());

            Point[] points = new Point[count];

            for (int i = 0; i < count; i++)
            {
                points[i] = Point.ParsePoint(Console.ReadLine());
            }

            double minDistance;
            Point[] targerPoints;

            MinDistans(points, out minDistance, out targerPoints);

            Console.WriteLine($"{minDistance:F2}");
            Console.WriteLine($"({targerPoints[0].X},{targerPoints[0].Y})");
            Console.WriteLine($"({targerPoints[1].X},{targerPoints[1].Y})");
        }

        private static void MinDistans(Point[] points, out double minDistance, out Point[] targerPoints)
        {
            minDistance = double.MaxValue;
            targerPoints = new Point[2];
            for (int i = 0; i < points.Length; i++)
            {
                for (int j = i + 1; j < points.Length; j++)
                {
                    double currentDistance = CalculatedDistance(points[i], points[j]);

                    if (currentDistance < minDistance)
                    {
                        minDistance = currentDistance;
                        targerPoints[0] = points[i];
                        targerPoints[1] = points[j];
                    }
                }
            }
        }

        static double CalculatedDistance(Point point1, Point point2)
        {
            double distance = 0;
            int side1 = Math.Abs(point1.X - point2.X);
            int side2 = Math.Abs(point1.Y - point2.Y);

            return distance = Math.Sqrt(side1 * side1 + side2 * side2);
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

        public static Point ParsePoint(string input)
        {
            int[] inputArg = input.Split(' ').Select(int.Parse).ToArray();

            return new Point(inputArg[0], inputArg[1]);
        }
    }

}
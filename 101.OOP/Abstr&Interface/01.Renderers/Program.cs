using Renderers.Renderers;
using Renderers.Shapes;

namespace Renderers
{
    public class Program
    {
        static void Main(string[] args)
        {
            IRenderer renderer = new ConsoleRenderer();

            List<IShape> shape = new List<IShape>();

            shape.Add(new Circle(renderer));
            shape.Add(new Square(renderer));
            shape.Add(new Square(renderer));
            shape.Add(new Text(renderer, "Hello"));
            shape.Add(new Text(renderer, "How Are you"));



            foreach (var item in shape)
            {
                item.Draw();

                Console.WriteLine();
                Console.WriteLine();
                
            }
        }
    }
}
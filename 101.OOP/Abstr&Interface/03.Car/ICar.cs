
using System.Runtime.CompilerServices;

namespace Car
{
    public abstract class  ICar
    {
        protected string model;
        protected string color;

        protected ICar(string model, string color)
        {
            this.model = model;
            this.color = color;
        }

        protected  string Start()
        {
            return "Engine start";
        } 

        protected string End()
        {
            return "Breaaak!";
        }
    }
}

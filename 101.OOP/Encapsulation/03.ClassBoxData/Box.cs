using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ClassBoxData
{
    public class Box
    {
		private double length; 
        private double width;
        private double height;

        public Box(double length, double width, double height)
        {
            this.Length = length;
            this.Width = width;
            this.Height = height;
        }

        public double Length
		{
			get { return length; }

			private set 
			{
                if (value <= 0)
                {
					throw new ArgumentException($"Length cannot be zero or negative.");
                }

                length = value; 
			}	
		}       

        public double Width 
        {
            get { return width; }

            private set
            {
                if (value <= 0)
                {
                    throw new ArgumentException($"Width cannot be zero or negative.");
                }

                width = value;
            }
        }       

        public double Height 
        {
            get { return height; }

            private set
            {
                if (value <= 0)
                {
                    throw new ArgumentException($"Height cannot be zero or negative.");
                }

                height = value;
            }
        }


        private double SurfaceArea()
        {
            return (2 * length * width)  + (2 * length  * height) + (2 * width * height); 
        }

        private double LateralSurfaceArea()
        {
            return 2 * height * (width + length);
        }

        private double Volume()
        {
            return length * height * width;
        }

        public override string ToString()
        {
            StringBuilder sb = new StringBuilder();

            sb.AppendLine($"Surface Area - {this.SurfaceArea():F2}");
            sb.AppendLine($"Lateral Surface Area - {this.LateralSurfaceArea():F2}");
            sb.AppendLine($"Volume - {this.Volume():F2}");

            return sb.ToString().Trim();
        }


    }
}

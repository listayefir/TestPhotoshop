using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace MyPhotoshop
{
    public struct Pixel
    {
        public Pixel(double r, double g, double b)
        {
            this.r = this.g = this.b = 0;
            R = r;
            G = g;
            B = b;
        }

        

        public static double Trim(double value)
        {
            if (value < 0) return 0;
            if (value > 1) return 1;
            return value;
        }

        public double CheckChannel(double value)
        {
            if (value < 0 || value > 1)
                throw new Exception(string.Format("Wrong channel value {0} (the value must be between 0 and 1", value));
            else return value;
        }
       
        private double r;
        public double R
        { get { return r; }
          set { r = CheckChannel(value); }         
        }


        private double g;
        public double G
        {
            get { return g; }
            set { g = CheckChannel(value); }
        }

        private double b;
        public double B
        {
            get { return b; }
            set { b = CheckChannel(value); }
        }

       public static Pixel operator *(Pixel pixel, double coefficient)
        {
            return new Pixel(Pixel.Trim(pixel.R * coefficient),
                             Pixel.Trim(pixel.G * coefficient),
                             Pixel.Trim(pixel.B * coefficient));
        }

        public static Pixel operator *(double coefficient, Pixel pixel)
        {
            return new Pixel(Pixel.Trim(pixel.R * coefficient),
                             Pixel.Trim(pixel.G * coefficient),
                             Pixel.Trim(pixel.B * coefficient));
        }

    }
}

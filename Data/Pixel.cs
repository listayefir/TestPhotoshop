using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace MyPhotoshop
{
    public class Pixel
    {
        private double r;
        private double g;
        private double b;

        public double R
        { get { return r; }
          set { r = CheckChannel(value); }         
        }

        public double G
        {
            get { return g; }
            set { g = CheckChannel(value); }
        }
        
        public double B
        {
            get { return b; }
            set { b = CheckChannel(value); }
        }

        public Pixel()
        {

        }

        public double CheckChannel(double value)
        {
            if (value < 0 || value > 1)
                throw new Exception(string.Format("Wrong channel value {0} (the value must be between 0 and 1", value));
            else return value;
        }
       
    }
}

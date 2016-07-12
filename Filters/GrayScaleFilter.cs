using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace MyPhotoshop.Filters
{
    public class GrayScaleFilter:PixelFilter
    {
        public GrayScaleFilter() : base(new GreyScaleParameters()) { }

       

           
        public override Pixel ProcessPixel(Pixel pixel, IParameters parameters)
        {
            var lightness = pixel.R + pixel.G + pixel.B;
            lightness /= 3;
            return new Pixel(lightness, lightness, lightness);
        }

        public override string ToString()
        {
            return "Оттенки серого";
        }

      
        
        
    }
}

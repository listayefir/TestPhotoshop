using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace MyPhotoshop.Filters
{
    public class GrayScaleFilter : IFilter
    {
        public ParameterInfo[] GetParameters()
        {
            return new ParameterInfo[0];
        }

        public Photo Process(Photo original, double[] parameters)
        {

            var result = new Photo(original.width, original.height);

            for (int x = 0; x < result.width; x++)
                for (int y = 0; y < result.height; y++)
                {
                    var lightness = original[x, y].R + original[x, y].G + original[x, y].B;
                    lightness /= 3;
                    result[x, y] = new Pixel(lightness,lightness,lightness);
                }
            return result;
        }

        public override string ToString()
        {
            return "Оттенки серого";
        }

    }
}

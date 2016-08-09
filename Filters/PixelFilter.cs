using MyPhotoshop.Filters;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace MyPhotoshop.Filters
{
    public class PixelFilter<TParameters>:ParametrizedFilter<TParameters>
        where TParameters:IParameters, new()
    {

        string filterName;
        Func<Pixel, TParameters, Pixel> processPixel;

        public PixelFilter(string filter, Func<Pixel, TParameters, Pixel> processPixel)
            {
            this.filterName = filter;
            this.processPixel = processPixel;
            }

        

        public override Photo Process(Photo original, TParameters parameters)
        {

            var result = new Photo(original.width, original.height);

            for (int x = 0; x < result.width; x++)
                for (int y = 0; y < result.height; y++)
                {
                    result[x, y] = processPixel(original[x, y], parameters);
                }
            return result;
        }

        public override string ToString()
        {
            return filterName;
        }


    }
}

using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace MyPhotoshop.Filters
{
   public abstract class ParametrizedFilter:IFilter
    {
        IParameters parameters;

        public ParametrizedFilter(IParameters parameters)
        {
            this.parameters = parameters;
        }

        public ParameterInfo[] GetParameters()
        {
            return parameters.GetDescription();
        }

        public abstract Photo Process(Photo original, IParameters parameters);

        public Photo Process(Photo original, double[] values)
        {
            this.parameters.Parse(values);
            return Process(original, this.parameters);

        }

        public abstract Pixel ProcessPixel(Pixel pixel, IParameters parameters);
       
    }
}

using System;
using System.Collections.Generic;
using System.Drawing;
using System.Linq;
using System.Text;

namespace MyPhotoshop.Filters
{
    class TransformFilter<TParameters> : ParametrizedFilter<TParameters>
        where TParameters:IParameters,new()
    {
        ITransformer<TParameters> transformer;
        string name;

        public TransformFilter(string name, ITransformer<TParameters> transformer)
        {
            this.name = name;
            this.transformer = transformer;
        }

        public override string ToString()
        {
            return name;
        }


        public override Photo Process(Photo original, TParameters parameters)
        {
            transformer.Prepare(new Size(original.width, original.height), parameters);
           
            var newSize = transformer.ResultSize;
            var result = new Photo(newSize.Width, newSize.Height);

            for (int x=0; x<newSize.Width;x++)
                for(int y = 0; y < newSize.Height; y++)
                {
                    var point = new Point(x, y);
                    var oldPoint = transformer.MapPoint(point);
                    if (oldPoint.HasValue)
                    result[x, y] = original[oldPoint.Value.X, oldPoint.Value.Y];
                }
            return result;
        }


    }
}

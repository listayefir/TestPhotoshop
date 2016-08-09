using System;
using System.Collections.Generic;
using System.Drawing;
using System.Linq;
using System.Text;

namespace MyPhotoshop.Filters
{
    public class FreeTransformer : ITransformer<EmptyParameters>
    {
        Func<Size, Size> sizeTransform;
        Func<Point, Size, Point> pointTransform;

        Size oldSize;

        public FreeTransformer(Func<Size, Size> sizeTransform, Func<Point, Size, Point> pointTransform)
        {
            this.sizeTransform = sizeTransform;
            this.pointTransform = pointTransform;
        }

        public Size ResultSize { get; private set; }
      

        public Point? MapPoint(Point newPoint)
        {
            return pointTransform(newPoint, oldSize);
        }

        public void Prepare(Size size, EmptyParameters parameters)
        {
            oldSize = size;
            ResultSize = sizeTransform(oldSize);
        }
    }
}

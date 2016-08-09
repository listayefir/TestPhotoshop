using System;
using System.Collections.Generic;
using System.Drawing;
using System.Linq;
using System.Text;

namespace MyPhotoshop.Filters
{
    public class RotateTransformer : ITransformer<RotationParameters>
    {
        public Size OriginalSize { get; private set; }
        public Size ResultSize { get; private set; }
        public double Angle { get; private set; }         

        public Point? MapPoint(Point newPoint)
        {           
            var oldSize = OriginalSize;
            var newSize = ResultSize;
            newPoint = new Point(newPoint.X - newSize.Width / 2, newPoint.Y - newSize.Height / 2);

            var x = oldSize.Width / 2 + (int)(newPoint.X * Math.Cos(Angle) + newPoint.Y * Math.Sin(Angle));
            var y = oldSize.Height / 2 + (int)(-newPoint.X * Math.Sin(Angle) + newPoint.Y * Math.Cos(Angle));

            if (x < 0 || x >= oldSize.Width || y < 0 || y >= oldSize.Height) return null;
            return new Point(x, y);
        }

        public void Prepare(Size size, RotationParameters parameters)
        {
            this.OriginalSize = size;                      
            this.Angle = Math.PI * parameters.Angle / 180;
            this.ResultSize= new Size(
                (int)(OriginalSize.Width * Math.Abs(Math.Cos(Angle)) + OriginalSize.Height * Math.Abs(Math.Sin(Angle))),
                (int)(OriginalSize.Height * Math.Abs(Math.Cos(Angle)) + OriginalSize.Width * Math.Abs(Math.Sin(Angle))));
        }
    }
}

using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Convex_Hull
{
    public class Point
    {
        public float X { get; set; }
        public float Y { get; set; }

        public Point()
        {
            X = 0;
            Y = 0;
        }

        public Point(Point point)
        {
            X = point.X;
            Y = point.Y;
        }

        public Point(float X, float Y)
        {
            this.X = X;
            this.Y = Y;
        }

        public void SetRandomValueBetween(float minimumX, float maximumX, float minimumY, float maximumY)
        {
            Random random = new Random();
            X = (float)random.NextDouble() * (maximumX - minimumX) + minimumX;
            Y = (float)random.NextDouble() * (maximumY - minimumY) + minimumY;
        }
    }
}
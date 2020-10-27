using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Convex_Hull
{
    public class ConvexHull
    {
        public enum Direction { Left, TheSame, Right };
        private List<Point> points = new List<Point>();

        public ConvexHull(List<Point> points)
        {
            this.points = points;
        }

        private double CrossProduct(Point O, Point A, Point B)
        {
            return (A.X - O.X) * (B.Y - O.Y) - (A.Y - O.Y) * (B.X - O.X);
        }

        private Direction Side(double crossProduct)
        {
            if (crossProduct < 0)
                return Direction.Left;
            else if (crossProduct > 0)
                return Direction.Right;
            else
                return Direction.TheSame;
        }

        public List<Point> ComputeConvexHull()
        {
            if (points == null)
                return null;

            if (points.Count() <= 1)
                return points;

            int n = points.Count();
            int k = 0;
            List<Point> convexHull = new List<Point>(new Point[2 * n]);

            // Sortowanie Linq
            //points.Sort((a, b) => a.X == b.X ? a.Y.CompareTo(b.Y) : a.X.CompareTo(b.X));

            points = MergeSort.Sort(points);

            for (int i = 0; i < n; i++)
            {
                while (k >= 2 && Side(CrossProduct(convexHull[k - 2], convexHull[k - 1], points[i])) != Direction.Right)
                    k--;
                convexHull[k++] = points[i];
            }

            int t = k + 1;
            for (int i = n - 2; i >= 0; i--)
            {
                while (k >= t && Side(CrossProduct(convexHull[k - 2], convexHull[k - 1], points[i])) != Direction.Right)
                    k--;
                convexHull[k++] = points[i];
            }

            return convexHull.Take(k - 1).ToList();
        }

        public List<List<Point>> ComputeConvexHullStepByStep()
        {
            List<List<Point>> result = new List<List<Point>>();

            if (points == null)
                return null;

            if (points.Count() <= 1)
            {
                result.Add(points);
                return result;
            }

            int n = points.Count();
            int k = 0;
            List<Point> convexHull = new List<Point>(new Point[2 * n]);

            // Sortowanie Linq
            //points.Sort((a, b) => a.X == b.X ? a.Y.CompareTo(b.Y) : a.X.CompareTo(b.X));

            points = MergeSort.Sort(points);

            for (int i = 0; i < n; i++)
            {
                while (k >= 2 && Side(CrossProduct(convexHull[k - 2], convexHull[k - 1], points[i])) != Direction.Right)
                    k--;
                convexHull[k++] = points[i];
                result.Add(convexHull.ToList());
            }

            for (int i = n - 2, t = k + 1; i >= 0; i--)
            {
                while (k >= t && Side(CrossProduct(convexHull[k - 2], convexHull[k - 1], points[i])) != Direction.Right)
                    k--;
                convexHull[k++] = points[i];
                result.Add(convexHull.ToList());
            }

            result.Add(convexHull.Take(k - 1).ToList());
            return result;
        }
    }
}
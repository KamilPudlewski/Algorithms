using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Convex_Hull
{
    public class MergeSort
    {
        public static List<Point> Sort(List<Point> points)
        {
            if (points.Count <= 1)
            {
                return points;
            }

            List<Point> first = new List<Point>();
            List<Point> second = new List<Point>();

            for (int i = 0; i < points.Count/2; i++)
            {
                first.Add(points[i]);
            }
            for (int i = points.Count/2; i < points.Count; i++)
            {
                second.Add(points[i]);
            }
            return Merge(Sort(first), Sort(second));
        }

        private static List<Point> Merge(List<Point> first, List<Point> second)
        {
            List<Point> merged = new List<Point>(first.Count + second.Count);
            int indexFirst = 0;
            int indexSecond = 0;

            for (int indexMerged = 0; indexMerged < merged.Capacity; indexMerged++)
            {
                if (indexFirst >= first.Count)
                {
                    merged.Add(second[indexSecond++]);
                }
                else if (indexSecond >= second.Count)
                {
                    merged.Add(first[indexFirst++]);
                }
                else if (first[indexFirst].X < second[indexSecond].X)
                {
                    merged.Add(first[indexFirst++]);
                }
                else if (first[indexFirst].X > second[indexSecond].X)
                {
                    merged.Add(second[indexSecond++]);
                }
                else
                {
                    if (first[indexFirst].Y < second[indexSecond].Y)
                    {
                        merged.Add(first[indexFirst++]);
                    }
                    else
                    {
                        merged.Add(second[indexSecond++]);
                    }
                }
            }
            return merged;
        }
    }
}

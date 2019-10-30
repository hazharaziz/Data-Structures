using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using TestCommon;

namespace A5
{
    public class Q6ClosestPoints : Processor
    {
        public Q6ClosestPoints(string testDataName) : base(testDataName)
        { }
        public override string Process(string inStr) =>
            TestTools.Process(inStr, (Func<long, long[], long[], double>)Solve);

        public virtual double Solve(long n, long[] xPoints, long[] yPoints)
        {
            Point[] points = new Point[n];
            for (long i = 0; i < n; i++)
                points[i] = new Point(xPoints[i], yPoints[i]);
            points = points.OrderByDescending(p => p.X).Reverse().ToArray();
            string result = string.Format("{0:0.0000}",ClosestDist(n, points));
            return double.Parse(result);
        }

        //ClosestDist Method returning the minimun distance betweeen a pair of points
        private double ClosestDist(long n, Point[] points)
        {
            if (n <= 3)
                return CalcPointsDist(n, points);
            long mid = n / 2;
            Point midPoint = points[mid];
            Point[] leftPoints = SubArray(points, 0, mid);
            Point[] rightPoints = SubArray(points, mid, n);
            double leftDist = ClosestDist(leftPoints.Length, leftPoints);
            double rightDist = ClosestDist(rightPoints.Length, rightPoints);
            double tempMinDist = Math.Min(leftDist, rightDist);
            Point[] stripPoints = GetStripPoints(midPoint, tempMinDist, points);
            if (tempMinDist != 0)
            {
                double stripMinDist = StripMinDist(stripPoints, tempMinDist, stripPoints.Length);
                tempMinDist =  Math.Min(tempMinDist, stripMinDist);
            }
            return tempMinDist;
        }

        //StripMinDist Method returning the minimum distance 
        //between the points in the strip
        private double StripMinDist(Point[] stripPoints, double tempMinDist, long n)
        {
            double minStripDist = long.MaxValue;
            stripPoints = stripPoints.OrderByDescending(p => p.Y).Reverse().ToArray();
            for (long i = 0; i < n; i++)
                for (long j = i + 1; j < n &&
                    (stripPoints[j].Y - stripPoints[i].Y < tempMinDist); j++)
                {
                    double distance = CalcDist(stripPoints[j], stripPoints[i]);
                    if (distance < minStripDist)
                        minStripDist = distance;
                }
            return minStripDist;
        }

        //CalcDist Method returning the distance between two points
        private double CalcDist(Point point1, Point point2) =>
            Math.Sqrt(Math.Pow(point1.X - point2.X, 2) + Math.Pow(point1.Y - point2.Y, 2));

        //GetStripPoints Method returning the array including the points
        //in the strip
        private Point[] GetStripPoints(Point midPoint, double tempMinDist, Point[] points)
        {
            List<Point> stripPoints = new List<Point>();
            long n = points.Length;
            for (long i = 0; i < n; i++)
                if (Math.Abs(points[i].X - midPoint.X) <= tempMinDist)
                    stripPoints.Add(points[i]);
            return stripPoints.ToArray();
        }

        //SubArray Method returning the subArray of a given array
        private Point[] SubArray(Point[] points, long start, long end)
        {
            Point[] result = new Point[end - start];
            long index = 0;
            for (long i = start; i < end; i++)
            {
                result[index] = points[i];
                index++;
            }
            return result;
        }

        //CalcPointsDist Method returning the minimum distance between 
        //points of an array with less than 4 elements
        private double CalcPointsDist(long n, Point[] points)
        {
            double minDistance = double.MaxValue;
            for (int i = 0; i < n; i++)
                for (int j = i + 1; j < n; j++)
                {
                    double distance = Math.Sqrt(Math.Pow(points[i].X - points[j].X, 2)
                                                + Math.Pow(points[i].Y - points[j].Y, 2));
                    if (distance < minDistance)
                        minDistance = distance;
                }
            return minDistance;
        }
    }
}
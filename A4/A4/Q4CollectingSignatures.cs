using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using TestCommon;

namespace A4
{
    public class Q4CollectingSignatures : Processor
    {
        public Q4CollectingSignatures(string testDataName) : base(testDataName)
        {}

        public override string Process(string inStr) =>
            TestTools.Process(inStr, (Func<long, long[], long[], long>) Solve);


        public virtual long Solve(long tenantCount, long[] startTimes, long[] endTimes)
        {
            List<Segment> segments = GetSortedSegments(tenantCount, startTimes, endTimes);
            long count = 0;
            while (segments.Count > 0)
            {
                Segment firstSegment = new Segment(segments[0].StartPoint,
                                                   segments[0].EndPoint);
                bool hasIntersection = false;
                foreach (Segment segment in segments)
                {
                    if (segment.StartPoint <= firstSegment.EndPoint &&
                        segment.EndPoint >= firstSegment.EndPoint)
                    {
                        hasIntersection = true;
                        segments[segments.IndexOf(segment)].Checked = true;
                    }
                }
                count += (hasIntersection) ? 1 : 0;
                segments = segments.Where(s => !(s.Checked)).ToList();
            }
            return count;
        }

        //GetSortedSegments method returning the sorted segments(sorted by endPoints)
        private List<Segment> GetSortedSegments(long tenantCount, long[] startTimes, long[] endTimes)
        {
            List<Segment> segments = new List<Segment>();
            for (int i = 0; i < tenantCount; i++)
            {
                segments.Add(new Segment(startTimes[i], endTimes[i]));
            }
            segments = segments.OrderByDescending(s => s.EndPoint).Reverse().ToList();
            return segments;
        }
    }
}

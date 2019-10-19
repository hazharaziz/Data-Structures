namespace A4
{
    public class Segment
    {
        public long StartPoint { get; set; }
        public long EndPoint { get; set; }
        public bool Checked { get; set; }
        public Segment(long start, long end)
        {
            StartPoint = start;
            EndPoint = end;
        }
    }
}
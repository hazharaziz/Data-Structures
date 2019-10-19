namespace A4
{
    public class Item
    {
        public long Weight { get; set; }
        public long Value { get; set; }
        public double ValueDensity { get; set; }

        public Item(long weight, long value)
        {
            Weight = weight;
            Value = value;
            ValueDensity = (double)value / weight;
        }
    }
}
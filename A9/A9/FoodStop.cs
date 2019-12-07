namespace A9
{
    public class FoodStop
    {
        public long Distance { get; set; }
        public long Food { get; set; }

        public FoodStop(long distance, long food = 0)
        {
            Distance = distance;
            Food = food;
        }
    }
}
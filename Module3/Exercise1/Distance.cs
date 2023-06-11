namespace Exercise1
{
    public class Distance
    {
        public double Value { get; set; }

        public override string ToString()
        {
            return $"{Math.Round(Value, 4)} km";
        }
    }
}

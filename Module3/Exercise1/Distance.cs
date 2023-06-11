namespace Exercise1
{
    public class Distance
    {
        private const double KM_TO_MILE_RATIO = 0.621371;

        private Distance(double value)
        {
            CheckValue(value);
            Value = value;
        }

        public static Distance New(double value)
        {
            return new Distance(value);
        }

        public Distance ChangeValue(double value)
        {
            CheckValue(value);
            Value = value;
            return this;
        }

        public double Value { get; private set; }

        public string DisplayAsKilometers()
        {
            return $"{Math.Round(Value, 4)} km";
        }

        public string DisplayAsMiles()
        {
            return $"{Math.Round(Value * KM_TO_MILE_RATIO, 4)} mi";
        }

        private static void CheckValue(double value)
        {
            if (value < 0)
            {
                throw new ArgumentException($"Value '{value}' cannot be negative");
            }
        }
    }
}

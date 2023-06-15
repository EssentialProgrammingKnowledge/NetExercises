namespace Exercise2
{
    public class Sport : ICarType<Sport>
    {
        public Sport Identify()
        {
            return this;
        }
    }
}

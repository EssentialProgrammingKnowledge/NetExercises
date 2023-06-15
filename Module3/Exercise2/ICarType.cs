namespace Exercise2
{
    public interface ICarType<T>
        where T : ICarType<T>
    {
        public T Identify();
    }
}

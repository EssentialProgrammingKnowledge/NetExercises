namespace Task2
{
    public abstract class Car
    {
        public int Id { get; set; }
        public string Name { get; set; }
        public string Description { get; set; }
        public string Type { get; set; }

        public virtual void Honk()
        {
            Console.WriteLine("Horn");
        }

        public abstract void Start();

        public abstract void Stop();

        public void Abs()
        {
            Stop();
        }
    }
}

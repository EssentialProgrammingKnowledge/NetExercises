namespace Task2
{
    public class Car
    {
        public int Id { get; set; }
        public string Name { get; set; }
        public string Description { get; set; }
        public string Type { get; set; }

        public void Honk()
        {
            Console.WriteLine("Horn");
        }

        public void Start()
        {
            Console.WriteLine("Start!");
        }

        public void Stop()
        {
            Console.WriteLine("Stop!");
        }
    }
}

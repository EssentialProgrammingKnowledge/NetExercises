using Task2;

namespace Exercise2
{
    public class Audi : Car
    {
        public override void Start()
        {
            Console.WriteLine("Audi Start!");
        }

        public override void Stop()
        {
            Console.WriteLine("Audi Stop");
        }

        public override void Honk()
        {
            Console.WriteLine("Audi Honk!");
        }
    }
}

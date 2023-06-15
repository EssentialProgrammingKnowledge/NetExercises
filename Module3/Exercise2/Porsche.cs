using Task2;

namespace Exercise2
{
    public class Porsche : Car
    {
        public override void Start()
        {
            Console.WriteLine("Porsche Start!");
        }

        public override void Stop()
        {
            Console.WriteLine("Porsche Stop");
        }

        public override void Honk()
        {
            Console.WriteLine("Porsche Honk!");
        }
    }
}

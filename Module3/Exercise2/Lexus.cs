using Task2;

namespace Exercise2
{
    public class Lexus : Car
    {
        public override void Start()
        {
            Console.WriteLine("Lexus Start!");
        }

        public override void Stop()
        {
            Console.WriteLine("Lexus Stop");
        }

        public override void Honk()
        {
            Console.WriteLine("Lexus Honk!");
        }
    }
}

using Task2;

namespace Exercise2
{
    public class BMW : Car
    {
        public override void Start()
        {
            Console.WriteLine("BMW Start!");
        }

        public override void Stop()
        {
            Console.WriteLine("BMW Stop");
        }
    }
}

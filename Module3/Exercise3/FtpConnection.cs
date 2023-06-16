namespace Exercise3
{
    public class FtpConnection
    {
        public FtpConnection()
        {
            Console.WriteLine("Connection with FTP established");
        }

        public void Send<T>(T obj) where T : class
        {
            Console.WriteLine($"Send {obj.GetType().FullName}");
        }
    }
}

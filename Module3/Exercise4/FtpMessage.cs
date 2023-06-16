namespace Exercise4
{
    public class FtpMessage
    {
        public int Port { get; set; }
        public string Content { get; set; }

        public override string ToString()
        {
            return $"Port {Port}; Content {Content}";
        }
    }
}

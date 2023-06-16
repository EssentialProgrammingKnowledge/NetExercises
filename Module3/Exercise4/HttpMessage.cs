namespace Exercise4
{
    public class HttpMessage
    {
        public string Url { get; set; }
        public int Port { get; set; }
        public string Content { get; set; }

        public override string ToString()
        {
            return $"Url {Url}; Port {Port}; Content {Content}";
        }
    }
}

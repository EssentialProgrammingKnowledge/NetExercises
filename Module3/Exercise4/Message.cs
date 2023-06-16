namespace Exercise4
{
    public class Message
    {
        public string Content { get; set; }

        public void Send()
        {
            if (string.IsNullOrWhiteSpace(Content))
            {
                throw new ArgumentNullException($"Invalid arguments, check if not null '{nameof(Content)}'");
            }

            Console.WriteLine("Sent message!");
        }

        public override string ToString()
        {
            return $"Content {Content}";
        }
    }
}

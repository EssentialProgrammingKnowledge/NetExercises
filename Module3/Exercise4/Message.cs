namespace Exercise4
{
    public class Message
    {
        public string Content { get; }

        private Message(string content) 
        {
            Content = content;
        }

        public static Message Create(string value)
        {
            if (string.IsNullOrWhiteSpace(value))
            {
                throw new ArgumentNullException($"Invalid arguments, check if not null '{nameof(value)}'");
            }

            return new Message(value);
        }

        public override string ToString()
        {
            return $"Content {Content}";
        }
    }
}

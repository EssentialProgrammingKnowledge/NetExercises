namespace Exercise3
{
    public class MessageHandler
    {
        public Action<string> OnSendMessage;
        public event EventHandler<string> OnSendMessageEventHandler;

        public void SendMessage(string message)
        {
            Console.WriteLine($"Message Send {message}");
            OnSendMessage(message);
            OnSendMessageEventHandler.Invoke(this, message);
        }
    }
}

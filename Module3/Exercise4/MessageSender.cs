namespace Exercise4
{
    public class MessageSender
    {
        public void SendMail(Message message)
        {
            Console.WriteLine("Sending mail");
        }

        public void SendHttpMessage(Message message)
        {
            Console.WriteLine("Sending http");
        }

        public void SendFtpMessage(Message message)
        {
            Console.WriteLine("Sending ftp");
        }
    }
}

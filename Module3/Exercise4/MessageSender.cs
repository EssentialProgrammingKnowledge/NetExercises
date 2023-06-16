namespace Exercise4
{
    // Tą klasę można było rozbić na kilka innych jednak chciałem pokazać że również w ten sposób można w jedenej klasie zaimplementować kilka interfejsów.
    // Jeśli chcielibyśmy użyć przykładowo użyć IMailMessageSender to możemy wykorzystać MessageSender, tak samo będzie w przypadku IHttpMessageSender i IFtpMessageSender
    // Taka sama implementacja została wykorzystana w klasie Service z tym że tam interfejs Service dziedziczył po wszystkich funkcjonalnościach.
    // Jak to działa? Zobacz główną metodę w klasie Program (patrz na obiekt service) i jak jest podstawiana wartość i jakie interfejsy należy przekazać w konstruktorze TokenService
    // Klasy EmailMessage, HttpMessage i FtpMessage wprowadziłem, ponieważ wysyłając wiadomość email, http czy na ftp mamy inną strukturę danych.
    // Oczywiście te przykłady nie odzwierciedlają rzeczywistych przypadków ale możesz zobaczyć takie klasy jak:
    // HttpClient, SmtpClient i sprawdzić jakie obiekty są potrzebne do wysłania wiadomości np metoda:
    // Send w HttpClient,
    // Send w SmtpClient
    public class MessageSender : IMailMessageSender, IHttpMessageSender, IFtpMessageSender
    {
        // Można utworzyć dodatkowo obiekty, które obsłużą wysłanie email, wysłanie wiadomości http, ftp.
        // Następnie przekazać je w konstruktorze i wywołać w odpowiedniej metodzie.
        public MessageSender()
        {
        }

        public void SendMail(EmailMessage message)
        {
            Console.WriteLine($"Sending mail {message}");
        }

        public void SendHttpMessage(HttpMessage message)
        {
            Console.WriteLine($"Sending http message {message}");
        }

        public void SendFtpMessage(FtpMessage message)
        {
            Console.WriteLine($"Sending ftp message {message}");
        }
    }
}

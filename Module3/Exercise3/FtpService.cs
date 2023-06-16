namespace Exercise3
{
    public class FtpService : Service
    {
        public void Send<T>(T obj) where T : class
        {
            _ftpConnection.Send(obj);
        }
    }
}

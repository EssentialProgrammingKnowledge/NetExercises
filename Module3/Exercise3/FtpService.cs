namespace Exercise3
{
    public class FtpService
    {
        private readonly FtpConnection _ftpConnection;

        public FtpService(FtpConnection ftpConnection)
        {
            _ftpConnection = ftpConnection;
        }

        public void Send<T>(T obj) where T : class
        {
            _ftpConnection.Send(obj);
        }
    }
}

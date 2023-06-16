namespace Exercise3
{
    public class Service
    {
        protected readonly DbConnection _dbConnection;
        protected readonly FtpConnection _ftpConnection;

        public Service()
        {
            _dbConnection = new DbConnection();
            _ftpConnection = new FtpConnection();
        }
    }
}

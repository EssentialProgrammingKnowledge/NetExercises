namespace Exercise3
{
    public class DbService
    {
        private readonly DbConnection _dbConnection;

        public DbService(DbConnection dbConnection)
        {
            _dbConnection = dbConnection;
        }

        public void Send<T>(T obj) where T : class
        {
            _dbConnection.Send(obj);
        }
    }
}

namespace Exercise3
{
    public class DbService : Service
    {
        public void Send<T>(T obj) where T : class
        {
            _dbConnection.Send(obj);
        }
    }
}

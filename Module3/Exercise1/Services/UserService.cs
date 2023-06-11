namespace Exercise1.Services
{
    public class UserService : Service
    {
        public void Add(User user)
        {
            base.Add(user);
        }

        public User? Get(int id)
        {
            return GetById(id) as User;
        }
    }
}

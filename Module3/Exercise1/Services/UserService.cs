namespace Exercise1.Services
{
    public class UserService
    {
        private readonly List<User> _users = new ();

        public void Add(User user)
        {
            int id = GetId();
            user.Id = id;
            _users.Add(user); 
        }

        public User? Get(int id)
        {
            foreach (User user in _users)
            {
                if (user.Id == id)
                {
                    return user;
                }
            }

            return null;
        }

        private int GetId()
        {
            return _users.Count > 0 ? _users[^1].Id + 1 : 1;
        }
    }
}

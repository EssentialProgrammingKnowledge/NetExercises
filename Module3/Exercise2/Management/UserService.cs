using System.Security.Claims;

namespace Exercise2.Management
{
    public class UserService
    {
        private readonly List<User> _users = new();

        public bool Add(UserDto userDto)
        {
            if (string.IsNullOrWhiteSpace(userDto.UserName))
            {
                return false;
            }

            if (string.IsNullOrWhiteSpace(userDto.Role))
            {
                return false;
            }

            var user = new User()
            {
                Id = userDto.Id,
                UserName = userDto.UserName,
                Role = userDto.Role,
                Claims = userDto.Claims,
            };
            user.Id = _users.Count > 0 ? _users[^1].Id + 1 : 1;
            _users.Add(user);
            return true;
        }

        public bool Delete(int id)
        {
            var user = GetUser(id);

            if (user is null)
            {
                return false;
            }

            _users.Remove(user);
            return true;
        }

        public bool Update(UserDto userDto)
        {
            var user = GetUser(userDto.Id);

            if (user is null)
            {
                return false;
            }

            if (string.IsNullOrWhiteSpace(userDto.UserName))
            {
                return false;
            }

            if (string.IsNullOrWhiteSpace(userDto.Role))
            {
                return false;
            }

            user.UserName = userDto.UserName;
            user.Role = userDto.Role;
            user.Claims = userDto.Claims ?? new List<Claim>();
            return true;
        }

        public UserDto? Get(int id)
        {
            var user = GetUser(id);

            if (user is null)
            {
                return null;
            }

            return new()
            {
                Id = user.Id,
                UserName = user.UserName,
                Role = user.Role,
                Claims = user.Claims
            };
        }

        public IReadOnlyList<UserDto> GetAll()
        {
            var users = new List<UserDto>();

            foreach (var user in _users)
            {
                users.Add(new UserDto()
                {
                    Id = user.Id,
                    UserName = user.UserName,
                    Role = user.Role,
                    Claims = user.Claims
                });
            }

            return users;
        }

        private User? GetUser(int id)
        {
            foreach (var user in _users)
            {
                if (user.Id == id)
                {
                    return user;
                }
            }

            return null;
        }
    }
}

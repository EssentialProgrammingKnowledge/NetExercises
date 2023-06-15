using System.Security.Claims;

namespace Exercise2.Management
{
    public class UserDto : BaseDto
    {
        public string UserName { get; set; }
        public string Role { get; set; }
        public List<Claim> Claims { get; set; }
    }
}

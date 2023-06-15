namespace Exercise2.Management
{
    public class UserService : BaseService<User, UserDto>
    {
        public override bool Add(UserDto userDto)
        {
            if (string.IsNullOrWhiteSpace(userDto.UserName))
            {
                return false;
            }

            if (string.IsNullOrWhiteSpace(userDto.Role))
            {
                return false;
            }

            base.Add(userDto);
            return true;
        }

        public override bool Update(UserDto userDto)
        {
            var user = GetEntity(userDto.Id);

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

            return base.Update(userDto);
        }

        protected override UserDto? Map(User? entity)
        {
            return entity.AsDto();
        }

        protected override User? Map(UserDto? dto)
        {
            return dto.AsEntity();
        }
    }
}

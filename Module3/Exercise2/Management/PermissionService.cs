namespace Exercise2.Management
{
    public class PermissionService : BaseService<Permission, PermissionDto>
    {
        public override bool Add(PermissionDto permissionDto)
        {
            if (string.IsNullOrWhiteSpace(permissionDto.PermisionName))
            {
                return false;
            }

            if (string.IsNullOrWhiteSpace(permissionDto.PermissionValue))
            {
                return false;
            }

            return base.Add(permissionDto);
        }

        public override bool Update(PermissionDto permissionDto)
        {
            var permission = GetEntity(permissionDto.Id);

            if (permission is null)
            {
                return false;
            }

            if (string.IsNullOrWhiteSpace(permission.PermisionName))
            {
                return false;
            }

            if (string.IsNullOrWhiteSpace(permission.PermissionValue))
            {
                return false;
            }

            return base.Update(permissionDto);
        }

        protected override PermissionDto? Map(Permission? entity)
        {
            return entity.AsDto();
        }

        protected override Permission? Map(PermissionDto? dto)
        {
            return dto.AsEntity();
        }
    }
}

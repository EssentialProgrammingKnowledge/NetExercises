namespace Exercise2.Management
{
    public class PermissionService
    {
        private readonly List<Permission> _permissions = new ();

        public bool Add(PermissionDto permissionDto)
        {
            if (string.IsNullOrWhiteSpace(permissionDto.PermisionName))
            {
                return false;
            }

            if (string.IsNullOrWhiteSpace(permissionDto.PermissionValue))
            {
                return false;
            }

            var permission = new Permission()
            { 
                Id = permissionDto.Id, 
                PermisionName = permissionDto.PermisionName, 
                PermissionValue = permissionDto.PermissionValue 
            };
            permission.Id = _permissions.Count > 0 ? _permissions[^1].Id + 1 : 1;
            _permissions.Add(permission);
            return true;
        }

        public bool Delete(int id)
        {
            var permission = _permissions.FirstOrDefault(p => p.Id == id);

            if (permission is null)
            {
                return false;
            }

            _permissions.Remove(permission);
            return true;
        }

        public bool Update(PermissionDto permissionDto)
        {
            var permission = _permissions.FirstOrDefault(p => p.Id == permissionDto.Id);

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

            permission.PermisionName = permissionDto.PermisionName;
            permission.PermissionValue = permissionDto.PermissionValue;
            return true;
        }

        public PermissionDto? Get(int id)
        {
            var permission = _permissions.FirstOrDefault(p => p.Id == id);

            if (permission is null)
            {
                return null;
            }

            return new ()
            {
                Id = permission.Id,
                PermisionName = permission.PermisionName,
                PermissionValue = permission.PermissionValue
            };
        }

        public IReadOnlyList<PermissionDto> GetAll()
        {
            var permissions = new List<PermissionDto>();

            foreach (var permission in _permissions)
            {
                permissions.Add(new PermissionDto()
                {
                    Id = permission.Id,
                    PermisionName = permission.PermisionName,
                    PermissionValue = permission.PermissionValue
                });
            }

            return permissions;
        }
    }
}

using Exercise2.Management;
using System.Security.Claims;

var tokenService = new TokenService();
var permissionService = new PermissionService();

var token = tokenService.IssueToken(new User 
{ 
    Id = 1, 
    UserName = "abc", 
    Role = "admin", 
    Claims = new List<Claim> 
    {
        new Claim("value1", "abc"),
        new Claim("value2", "def"),
    }
});

var user = tokenService.ExtractToken(token);
Console.WriteLine($"{user.Id} {user.UserName} {user.Role} {user.Claims}");

permissionService.Add(new PermissionDto
{
    Id = 1,
    PermisionName = "admin",
    PermissionValue = "issued"
});

var dto = permissionService.Get(1);
Console.WriteLine($"Id = {dto.Id} Name = {dto.PermisionName} Value = {dto.PermissionValue}");

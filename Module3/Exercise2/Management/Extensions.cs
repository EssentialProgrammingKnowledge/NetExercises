using System.Data;
using System.Security.Claims;
using System.Text;
using static System.Runtime.InteropServices.JavaScript.JSType;

namespace Exercise2.Management
{
    public static class Extensions
    {
        public static PermissionDto? AsDto(this Permission? entity)
        {
            return entity != null ? new PermissionDto
            {
                Id = entity.Id,
                PermisionName = entity.PermisionName,
                PermissionValue = entity.PermissionValue,
            } : null;
        }

        public static Permission? AsEntity(this PermissionDto? dto)
        {
            return dto != null ? new Permission
            {
                Id = dto.Id,
                PermissionValue = dto.PermissionValue,
                PermisionName = dto.PermisionName,
            } : null;
        }

        public static UserDto? AsDto(this User? entity)
        {
            return entity != null ? new UserDto
            {
                Id = entity.Id,
                UserName= entity.UserName,
                Role = entity.Role,
                Claims = entity.Claims
            } : null;
        }

        public static User? AsEntity(this UserDto? dto)
        {
            return dto != null ? new User
            {
                Id = dto.Id,
                UserName = dto.UserName,
                Role = dto.Role,
                Claims = dto.Claims
            } : null;
        }

        public static string AsString(this User user)
        {
            return $"""
                    userId: "{user.Id}"; userName: "{user.UserName}"; role: "{user.Role}";
                    claims: "{user.Claims.AsString()}"
                   """;
        }

        private static string AsString(this List<Claim> claims)
        {
            var claimsString = new StringBuilder("");
            foreach (var claim in claims)
            {
                claimsString.Append($"{claim.Type}: \"{claim.Value}\",");
            }
            return claimsString.Remove(claimsString.Length - 1, 1).ToString();
        }

        public static User AsUser(this string userString)
        {
            if (!userString.Contains(';'))
            {
                throw new InvalidOperationException("Invalid Format for user");
            }

            var values = userString.Split(";");
            return values.GetUserFromTextSplitted();
        }

        private static User GetUserFromTextSplitted(this string[] text)
        {
            if (text is null)
            {
                throw new ArgumentNullException("Invalid value text");
            }

            var errors = new StringBuilder();
            int userId = 0;
            string userName = "";
            string role = "";
            List<Claim> claims = new();

            foreach (var value in text)
            {
                if (string.IsNullOrWhiteSpace(value) || !value.Contains(':'))
                {
                    errors.Append($"Invalid format at value '{value}'");
                    continue;
                }

                var parameters = value.Split(":");
                var parameter = parameters[0].Trim();
                var parameterValue = parameters[1].Replace("\"", "").Trim();

                if (string.IsNullOrWhiteSpace(parameter))
                {
                    continue;
                }

                if (parameter == "userId")
                {
                    if (!int.TryParse(parameterValue, out userId))
                    {
                        errors.Append($"Invalid userId '{parameterValue}'");
                        continue;
                    }
                }

                if (parameter == "userName")
                {
                    userName = parameterValue;
                    continue;
                }

                if (parameter == "role")
                {
                    role = parameterValue;
                    continue;
                }

                if (parameter == "claims")
                {
                    try
                    {
                        claims = value.AsClaims();
                    }
                    catch (Exception ex)
                    {
                        if (ex is InvalidOperationException)
                        {
                            errors.Append(ex.Message);
                            continue;
                        }

                        throw;
                    }
                }
            }

            if (errors.Length > 0)
            {
                throw new InvalidOperationException(errors.ToString());
            }

            return new User
            {
                Id = userId,
                Role = role,
                UserName = userName,
                Claims = claims,
            };
        }

        private static List<Claim> AsClaims(this string claimsString)
        {
            if (string.IsNullOrWhiteSpace(claimsString) || !claimsString.Contains(':') || !claimsString.Contains(','))
            {
                throw new InvalidOperationException($"Invalid format at value '{claimsString}'");
            }

            var claimParameters = claimsString.Replace("claims:", "").Replace("\"", "").Split(",");
            var claims = new List<Claim>();
            var errors = new StringBuilder();

            foreach (var claimParameter in claimParameters)
            {
                if (string.IsNullOrWhiteSpace(claimParameter))
                {
                    continue;
                }

                if (!claimParameter.Contains(':'))
                {
                    errors.Append($"Invalid format at claim '{claimParameter}'");
                    continue;
                }

                var claimsTypeValue = claimParameter.Split(":");
                var claimType = claimsTypeValue[0].Trim();
                var claimValue = claimsTypeValue[1].Trim();

                if (string.IsNullOrWhiteSpace(claimType))
                {
                    continue;
                }

                claims.Add(new Claim(claimType, claimValue));
            }

            if (errors.Length > 0)
            {
                throw new InvalidOperationException(errors.ToString());
            }

            return claims;
        }
    }
}

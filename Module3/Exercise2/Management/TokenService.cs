using System.Security.Claims;
using System.Text;

namespace Exercise2.Management
{
    public class TokenService
    {
        private readonly List<Token> tokens = new();

        public TokenDto IssueToken(int userId, string userName, string role, List<Claim> claims)
        {
            if (string.IsNullOrWhiteSpace(userName))
            {
                throw new ArgumentNullException("userId shouldnt be null");
            }

            if (string.IsNullOrWhiteSpace(role))
            {
                throw new ArgumentNullException("role shouldnt be null");
            }

            var token = new Token()
            {
                Id = tokens.Count > 0 ? tokens[^1].Id + 1 : 1,
                // zmiana wartości string na postać base64 string aby jawnie nie pokazywać wartości
                // base64 łatwo przerobić na wartość string patrz metoda ExtractToken
                Value = Convert.ToBase64String(Encoding.UTF8.GetBytes(
                        $"""
                            userId: "{userId}"; userName: "{userName}"; role: "{role}";
                            claims: "{WriteClaims(claims)}"
                        """))
            };
            tokens.Add(token);

            return new TokenDto
            {
                Id = token.Id,
                AccessToken = token.Value
            };
        }

        public TokenDto? GetToken(int id)
        {
            foreach (var token in tokens)
            {
                if (token.Id == id)
                {
                    return new TokenDto { Id = token.Id, AccessToken = token.Value };
                }
            }

            return null;
        }

        public (int userId, string userName, string role, List<Claim> claims) ExtractToken(TokenDto token)
        {
            if (token is null)
            {
                throw new ArgumentNullException("Token cannot be null");
            }

            if (token.AccessToken is null)
            {
                throw new ArgumentException("AccessToken cannot be null");
            }

            var tokenValue = Encoding.UTF8.GetString(Convert.FromBase64String(token.AccessToken));

            if (string.IsNullOrEmpty(tokenValue))
            {
                throw new InvalidOperationException("Token is invalid");
            }

            var values = tokenValue.Split(";");
            int userId = 0;
            string userName = "";
            string role = "";
            List<Claim> claims = new();

            foreach (var value in values)
            { 
                var parameters = value.Split(":");
                var parameter = parameters[0].Trim();
                var parameterValue = parameters[1].Replace("\"", "").Trim();

                if (string.IsNullOrWhiteSpace(parameter))
                {
                    continue;
                }

                if (parameter == "userId")
                {
                    userId = Convert.ToInt32(parameterValue);
                }

                if (parameter == "userName")
                {
                    userName = parameterValue;
                }

                if (parameter == "role")
                {
                    role = parameterValue;
                }

                if (parameter == "claims")
                {
                    var claimParameters = value.Replace("claims:","").Replace("\"","").Split(",");

                    foreach (var claimParameter in claimParameters)
                    {
                        if (string.IsNullOrWhiteSpace(claimParameter))
                        {
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
                }
            }

            return (userId, userName, role, claims);
        }

        private static string WriteClaims(List<Claim> claims)
        {
            var claimsString = "";
            foreach (var claim in claims)
            {
                claimsString += $"{claim.Type}: \"{claim.Value}\",";
            }
            return claimsString.Remove(claimsString.Length - 1);
        }
    }
}

using System.Text;

namespace Exercise2.Management
{
    public class TokenService
    {
        private readonly List<Token> tokens = new();

        public TokenDto IssueToken(User user)
        {
            if (string.IsNullOrWhiteSpace(user.UserName))
            {
                throw new ArgumentNullException("userId shouldnt be null");
            }

            if (string.IsNullOrWhiteSpace(user.Role))
            {
                throw new ArgumentNullException("role shouldnt be null");
            }

            var token = new Token()
            {
                Id = tokens.Count > 0 ? tokens[^1].Id + 1 : 1,
                Value = Convert.ToBase64String(Encoding.UTF8.GetBytes(user.AsString()))
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

        public User ExtractToken(TokenDto token)
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

            return tokenValue.AsUser();
        }
    }
}

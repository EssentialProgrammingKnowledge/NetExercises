namespace Exercise4
{
    public class TokenService : Service<TokenDto>, IService<TokenDto>
    {
        public override int Add(TokenDto dto)
        {
            if (dto == null) 
            {
                throw new ArgumentNullException(nameof(dto));
            }

            if (string.IsNullOrWhiteSpace(dto.Value))
            {
                throw new InvalidOperationException("Token value cannot be null");
            }

            return base.Add(dto);
        }

        public override IList<TokenDto> GetAll()
        {
            throw new NotImplementedException();
        }

        public override void Update(TokenDto dto)
        {
            throw new NotImplementedException();
        }
    }
}

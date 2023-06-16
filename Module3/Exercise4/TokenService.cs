namespace Exercise4
{
    // Na potrzeby tej klasy rozdzielono interfejs Service na wszystkie operacje osobno, to pozwala wykorzystać ten sam obiekt do dedykowanych funkcjonalności a implementacja pozostaje ta sama.
    // Patrz na Program i główną metodę jak tam jest wykorzystywany obiekt service.
    // Dlaczego takie podejście?
    // Jak można było zauważyć nie wszystkie funkcjonalności oferowane przez serwis były potrzebne
    public class TokenService
    {
        private readonly IAddDtoService<TokenDto> _addDtoService;
        private readonly IGetDtoService<TokenDto> _getDtoService;
        private readonly IDeleteDtoService<TokenDto> _deleteDtoService;

        public TokenService(IAddDtoService<TokenDto> addToken, IGetDtoService<TokenDto> getToken, IDeleteDtoService<TokenDto> deleteToken) 
        { 
            _addDtoService = addToken;
            _getDtoService = getToken;
            _deleteDtoService = deleteToken;
        }

        public int Add(TokenDto dto)
        {
            if (dto == null) 
            {
                throw new ArgumentNullException(nameof(dto));
            }

            if (string.IsNullOrWhiteSpace(dto.Value))
            {
                throw new InvalidOperationException("Token value cannot be null");
            }

            return _addDtoService.Add(dto);
        }

        public void Delete(TokenDto dto)
        {
            _deleteDtoService.Delete(dto);
        }

        public TokenDto? Get(int id)
        {
            return _getDtoService.Get(id);
        }
    }
}

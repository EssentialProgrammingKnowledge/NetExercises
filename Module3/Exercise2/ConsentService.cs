namespace Exercise2
{
    public class ConsentService
    {
        private readonly List<Consent> _list = new();

        public void Add(ConsentDto item)
        {
            _list.Add(item.AsEntity());
        }

        public ConsentDto? Get(int id)
        {
            foreach (var item in _list)
            {
                if (item.Id == id)
                {
                    return item.AsDto();
                }
            }

            return null;
        }
    }
}

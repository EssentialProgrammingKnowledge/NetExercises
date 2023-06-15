namespace Exercise2
{
    public class ConsentService
    {
        private readonly List<Consent> _list = new();

        public void Add(ConsentDto item)
        {
            _list.Add(new () { Id = item.Id, Name = item.Name });
        }

        public ConsentDto? Get(int id)
        {
            foreach (var item in _list)
            {
                if (item.Id == id)
                {
                    return new ()
                    {
                        Id = item.Id,
                        Name = item.Name
                    };
                }
            }

            return null;
        }
    }
}

namespace Exercise2
{
    public class HeadphonesService
    {
        private readonly List<Headphones> _list = new();

        public void Add(HeadphonesDto item)
        {
            _list.Add(new () { Id = item.Id, Name = item.Name });
        }

        public HeadphonesDto? Get(int id)
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

namespace Exercise2
{
    public class HeadphonesService
    {
        private readonly List<Headphones> _list = new();

        public void Add(HeadphonesDto item)
        {
            _list.Add(item.AsEntity());
        }

        public HeadphonesDto? Get(int id)
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

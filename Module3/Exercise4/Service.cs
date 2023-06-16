namespace Exercise4
{
    public class Service<T> : IService<T>
        where T : class, IBaseDto
    {
        private readonly List<T> _items = new();

        public virtual int Add(T dto)
        {
            var id = _items.Count > 0 ? _items[^1].Id + 1 : 1;
            _items.Add(dto);
            return id;
        }

        public virtual void Delete(T dto)
        {
            _items.Remove(dto);
        }

        public virtual T? Get(int id)
        {
            foreach (var item in _items)
            {
                if (item.Id == id)
                {
                    return item;
                }
            }
            return null;
        }

        public virtual IList<T> GetAll()
        {
            return _items;
        }

        public virtual void Update(T dto)
        {
            var index = _items.FindIndex(i => i.Id == dto.Id);

            if (index == -1)
            {
                throw new InvalidOperationException($"Object with id '{dto.Id}' was not found");
            }

            _items[index] = dto;
        }
    }
}

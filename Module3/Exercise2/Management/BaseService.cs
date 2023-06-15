namespace Exercise2.Management
{
    public abstract class BaseService<T, U>
        where T : BaseEntity
        where U : BaseDto
    {
        protected readonly List<T> _list = new ();

        public virtual bool Add(U dto)
        {
            dto.Id = _list.Count > 0 ? _list[^1].Id + 1 : 1;
            _list.Add(Map(dto) ?? throw new ArgumentNullException("Entity cannot be null"));
            return true;
        }

        public virtual bool Delete(int id)
        {
            var entity = GetEntity(id);

            if (entity is null)
            {
                return false;
            }

            _list.Remove(entity);
            return true;
        }

        public virtual bool Update(U dto)
        {
            if (dto is null)
            {
                return false;
            }

            var index = FindIndex(dto.Id);
            if (index != -1)
            {
                return false;
            }

            _list[index] = Map(dto) ?? throw new ArgumentNullException("Entity cannot be null");
            return true;
        }

        public virtual U? Get(int id)
        {
            return Map(GetEntity(id));
        }

        public virtual IReadOnlyList<U> GetAll()
        {
            var list = new List<U>();
            foreach(var entity in _list)
            {
                if (entity is null)
                {
                    continue;
                }

                list.Add(Map(entity)!);
            }
            return list;
        }

        protected abstract U? Map(T? entity);

        protected abstract T? Map(U? dto);

        protected T? GetEntity(int id)
        {
            foreach (var entity in _list)
            {
                if (entity.Id == id)
                {
                    return entity;
                }
            }

            return null;
        }

        private int FindIndex(int id)
        {
            var index = -1;
            for (var i = 0; i < _list.Count; i++)
            {
                if (_list[i].Id == id)
                {
                    return i;
                }
            }
            return index;
        }
    }
}

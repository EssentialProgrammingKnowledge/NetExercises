namespace Exercise1.Services
{
    public class Service
    {
        protected List<BaseObject> _objects = new();

        protected void Add(BaseObject obj)
        {
            int id = GetId();
            obj.Id = id;
            _objects.Add(obj);
        }

        protected BaseObject? GetById(int id)
        {
            foreach (BaseObject obj in _objects)
            {
                if (obj.Id == id)
                {
                    return obj;
                }
            }

            return null;
        }

        protected int GetId()
        {
            return _objects.Count > 0 ? _objects[^1].Id + 1 : 1;
        }
    }
}

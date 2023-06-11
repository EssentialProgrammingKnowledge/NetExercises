namespace Exercise1.Services
{
    // wspólny serwis dla wszystkich serwisów a dlaczego? Zobacz że wszystkie serwisy wykorzystują te same metody
    // z tego względu lepiej jest pomyśleć nad wspólną klasą która będzie zawierać powtarzające się metody
    // dzięki polimorfizmowi możemy wykorzystać klasę BaseObject do dodawania wspólnych obiektów
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

namespace Exercise4
{
    // Każda z akcji została odpowiednio rozdielona. Dzięki temu każdy kto chciałby użyć np tylko dodawania dto a nie chciałby zmieniać obiektu może wykorzystać obiekt implementujący IService.
    // Patrz w głównej metodzie w klasie Program
    public interface IService<T> : IAddDtoService<T>, IUpdateDtoService<T>, IDeleteDtoService<T>, 
        IGetDtoService<T>, IGetAllDtoService<T>
        where T : class, IBaseDto
    {
    }

    public interface IAddDtoService<T>
        where T : class, IBaseDto
    {
        public int Add(T dto);
    }

    public interface IUpdateDtoService<T>
        where T : class, IBaseDto
    {
        public void Update(T dto);
    }

    public interface IDeleteDtoService<T>
        where T : class, IBaseDto
    {
        public void Delete(T dto);
    }

    public interface IGetDtoService<T>
        where T : class, IBaseDto
    {
        public T? Get(int id);
    }

    public interface IGetAllDtoService<T>
        where T : class, IBaseDto
    {
        public IList<T> GetAll();
    }
}

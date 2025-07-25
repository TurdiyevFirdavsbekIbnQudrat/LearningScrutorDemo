namespace ScrutorDemo
{
    public interface IGeneral<T> where T : class
    {
        bool Create(T value);
        IEnumerable<T> GetAll();
        IEnumerable<T> IfExistGetAll();
        string CleanCache();
    }
}

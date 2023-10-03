namespace DotNetCoreMVCDemo.DomainLayer.Interfaces
{
    public interface IRepository<T> where T : class
    {
        T GetById(object id);
        IList<T> GetAll();
        void Add(T entity);
        void Remove(T entity);
        void UpdateState(T entity);
        bool IsExists(T entity);
    }
}

using DotNetCoreMVCDemo.DomainLayer.Interfaces;
using Microsoft.EntityFrameworkCore;

namespace DotNetCoreMVCDemo.InfrastructureLayer.Data
{
    public class Repository<T> : IRepository<T> where T : class
    {
        private readonly DotNetCoreMVCDemoContext _dbContext;
        private readonly DbSet<T> _dbSet;

        public Repository(DotNetCoreMVCDemoContext dbContext)
        {
            _dbContext = dbContext;
            _dbSet = _dbContext.Set<T>();
        }

        public  T GetById(object id)
        {
            return _dbSet.Find(id);
        }
        public IList<T> GetAll()
        {
            return _dbSet.ToList();
        }

        #region DB Operation
        public void Add(T entity)
        {
            _dbSet.Add(entity);
        }
        public void Remove(T entity)
        {
            _dbSet.Remove(entity);
        }
        public bool IsExists(T entity)
        {
            try
            {
                var current = _dbContext.Entry(entity).OriginalValues;
                return true;
            }
            catch (Exception ex)
            {
                return false;
            }
        }
        public void UpdateState(T entity)
        {
            _dbSet.Entry(entity).State = EntityState.Modified;
        }

        #endregion
    }
}

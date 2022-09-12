using System.Linq.Expressions;

namespace BeerCollection.Data.Repositories.Interfaces
{
    public interface IBaseRepository<TEntity>
        where TEntity : class
    {
        Task<IEnumerable<TEntity>> GetAll();
        Task<TEntity> GetById(int id);
        Task<TEntity> Add(TEntity entity);
        Task<TEntity> Update(TEntity entity);
        IEnumerable<TEntity> Get(Expression<Func<TEntity, bool>> filter);
    }
}

using System.Linq;
using System.Threading.Tasks;

namespace Shop.Service.GenericRepository
{
    public interface IGenericRepository<TEntity> where TEntity : class
    {
        Task<TEntity> FindByIdAsync(object id);
        Task AddAsync(TEntity entity);
        void Delete(object id);
        void Delete(TEntity entityToDelete);
        void Update(TEntity entityToUpdate);
        IQueryable<TEntity> GetAll();
    }
}

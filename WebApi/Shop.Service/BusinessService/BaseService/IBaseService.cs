using System.Collections.Generic;
using System.Threading.Tasks;

namespace Shop.Service.BusinessService.BaseService
{
    public interface IBaseService<TEntity, TDto>
        where TEntity : class
        where TDto : class
    {
        Task CreateAsync(TDto dto);

        Task UpdateAsync(TDto dto);

        Task DeleteAsync(object keyValues);

        TDto FindById(object keyValues);

        IEnumerable<TDto> GetAll();
    }

}

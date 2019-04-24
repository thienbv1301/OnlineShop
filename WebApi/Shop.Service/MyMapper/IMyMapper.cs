using System.Collections.Generic;

namespace Shop.Service.MyMapper
{
    public interface IMyMapper<TEntity,TDto> 
        where TEntity : class
        where TDto : class
    {
        TDto EntityToDto(TEntity entity);
        TEntity DtoToEntity(TDto dto);
        IEnumerable<TDto> EntitiesToDtos(IEnumerable<TEntity> entities);
        IEnumerable<TEntity> DtosToEntities(IEnumerable<TDto> dtos);
    }
}

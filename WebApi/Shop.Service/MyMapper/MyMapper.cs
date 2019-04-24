using AutoMapper;
using System.Collections.Generic;

namespace Shop.Service.MyMapper
{
    public class MyMapper<TEntity, TDto> : IMyMapper<TEntity, TDto> 
        where TEntity : class
        where TDto : class
        
    {

        public IEnumerable<TEntity> DtosToEntities(IEnumerable<TDto> dtos)
        {
            return Mapper.Map<IEnumerable<TEntity>>(dtos);
        }

        public TEntity DtoToEntity(TDto dto)
        {
            return Mapper.Map<TEntity>(dto);
        }

        public IEnumerable<TDto> EntitiesToDtos(IEnumerable<TEntity> entities)
        {
            return Mapper.Map<IEnumerable<TDto>>(entities);
        }

        public TDto EntityToDto(TEntity entity)
        {
            return Mapper.Map<TDto>(entity);
        }
    }
}

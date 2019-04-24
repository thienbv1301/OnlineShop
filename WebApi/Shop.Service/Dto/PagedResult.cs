using System.Collections.Generic;

namespace Shop.Service.Dto
{
    public class PagedResult<TEntity> where TEntity:class
    {
        public int TotalRow { get; set; }
        public IEnumerable<TEntity> PageData { get; set; }
        public int PageIndex { get; set; }
        public int PageSize { get; set; }
    }
}

using Shop.Data.Models;
using Shop.Service.BusinessService.BaseService;
using Shop.Service.Dto;

namespace Shop.Service.BusinessService.ProductService
{
    public interface IProductService : IBaseService<Product,ProductDto>
    {
        PagedResult<ProductDto> PagedList(string searchString, int pageIndex, int pageSize);

    }
}

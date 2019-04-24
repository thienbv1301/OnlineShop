using Microsoft.AspNetCore.Mvc;
using Shop.Service.BusinessService.ProductService;
using Shop.Service.Dto;
using System.Linq;
using System.Threading.Tasks;

namespace Shop.WebApi.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class TestController : ControllerBase
    {
        private readonly IProductService _productService;
        public TestController(IProductService productService)
        {
            _productService = productService;
        }
        [HttpPost]
        public async Task<IActionResult> Create([FromBody] ProductDto product)
        {
            await _productService.CreateAsync(product);
            return Ok(_productService.GetAll());
        }
        [HttpGet]
        public IActionResult GetPagedList([FromQuery] string searchString, [FromQuery] int pageIndex, [FromQuery] int pageSize)
        {
            var result = _productService.PagedList(searchString, pageIndex, pageSize);
            if (result.PageData.Count() < 1)
            {
                return NotFound(result);
            }
            return Ok(result);
        }
    }
}
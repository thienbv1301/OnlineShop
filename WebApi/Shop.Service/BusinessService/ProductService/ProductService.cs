using Shop.Data.Models;
using Shop.Service.Dto;
using Shop.Service.GenericRepository;
using Shop.Service.MyMapper;
using Shop.Service.UnitOfWork;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace Shop.Service.BusinessService.ProductService
{
    public class ProductService : IProductService
    {
        private readonly IUnitOfWork _unitOfWork;
        private readonly IMyMapper<Product, ProductDto> _productMapper;
        private readonly IMyMapper<Image, ImageDto> _imageMapper;
        private readonly IGenericRepository<Product> _productRepository;
        private readonly IGenericRepository<Image> _imageRepository;
        private readonly IGenericRepository<Color> _colorRepository;
        private readonly IGenericRepository<Size> _sizeRepository;

        public ProductService(IUnitOfWork unitOfWork,
            IMyMapper<Product, ProductDto> productMapper,
            IMyMapper<Image, ImageDto> imageMapper)
        {
            _unitOfWork = unitOfWork;
            _productRepository = _unitOfWork.ProductRepository;
            _imageRepository = _unitOfWork.ImageRepository;
            _colorRepository = _unitOfWork.ColorRepository;
            _sizeRepository = _unitOfWork.SizeRepository;
            _productMapper = productMapper;
            _imageMapper = imageMapper;
        }

        public async Task CreateAsync(ProductDto dto)
        {
            var product = _productMapper.DtoToEntity(dto);
            product.Sku = CreateSku();
            product.Quantity = 0;
            await _productRepository.AddAsync(product);
            await _unitOfWork.SaveAsync();
        }

        public Task DeleteAsync(object keyValues)
        {
            throw new NotImplementedException();
        }

        public ProductDto FindById(object keyValues)
        {
            throw new NotImplementedException();
        }

        public Task UpdateAsync(ProductDto dto)
        {
            throw new NotImplementedException();
        }

        public IEnumerable<ProductDto> GetAll()
        {
            var listProduct = _productMapper.EntitiesToDtos(_productRepository.GetAll());
            return AddMoreInfo(listProduct);
        }

        private string CreateSku()
        {
            string sku = "SP" + DateTime.Now.ToBinary();
            return sku;
        }

        public PagedResult<ProductDto> PagedList(string searchString, int pageIndex, int pageSize)
        {
            var result = new PagedResult<ProductDto>();
            result.PageIndex = pageIndex;
            result.PageSize = pageSize;
            if (string.IsNullOrEmpty(searchString))
            {
                result.TotalRow = _productRepository.GetAll().Count();
                result.PageData= AddMoreInfo(_productMapper.EntitiesToDtos(_productRepository.GetAll().OrderBy(p => p.Id).Skip(pageSize * (pageIndex - 1)).Take(pageSize)));
            }
            else
            {
                result.TotalRow = _productRepository.GetAll().Where(p=>p.Name.Contains(searchString)).Count();
                result.PageData = AddMoreInfo(_productMapper.EntitiesToDtos(_productRepository.GetAll().Where(p => p.Name.Contains(searchString)).OrderBy(p => p.Id).Skip(pageSize * (pageIndex - 1)).Take(pageSize)));
            }
            return result;
        }
        private IEnumerable<ProductDto> AddMoreInfo(IEnumerable<ProductDto> listProduct)
        {
            foreach (var product in listProduct)
            {
                AddMoreInfo(product);
            }
            return listProduct;
        }
        private ProductDto AddMoreInfo(ProductDto product)
        {
            product.Images.AddRange(_imageMapper.EntitiesToDtos(_imageRepository.GetAll().Where(i => i.ProductId == product.Id)));
            product.Color = _colorRepository.FindByIdAsync(product.ColorId).Result.Name;
            product.Size = _sizeRepository.FindByIdAsync(product.SizeId).Result.Name;
            return product;
        }
    }
}

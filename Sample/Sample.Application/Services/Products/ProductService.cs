using AutoMapper;
using Sample.Core.Entities;
using Sample.DataAccess.Repositories.Products;
using Sample.Shared.Dtos.Products;
using Sample.Shared.SeedWorks;

namespace Sample.Application.Services.Products
{
    public class ProductService : IProductService
    {
        private readonly IProductRepository _productRepository;
        private readonly IMapper _mapper;
        public ProductService(IProductRepository productRepository, IMapper mapper)
        {
            _productRepository = productRepository;
            _mapper = mapper;
        }
        public ApiResult<ProductReponse> Create(CreateProductDto createProduct)
        {
            var product = _mapper.Map<Product>(createProduct);
            _productRepository.Add(product);
            return new ApiSuccessResult<ProductReponse>(true, "Thêm mới thành công", 200, null);
        }

        public List<ProductReponse> Get(Guid id)
        {
            throw new NotImplementedException();
        }

        public List<ProductReponse> GetAll()
        {
            throw new NotImplementedException();
        }

        public List<ProductReponse> GetPaging()
        {
            throw new NotImplementedException();
        }

        public ApiResult<ProductReponse> Update(CreateProductDto product)
        {
            throw new NotImplementedException();
        }

        public ApiResult<ProductReponse> Update(Guid id)
        {
            throw new NotImplementedException();
        }
    }
}

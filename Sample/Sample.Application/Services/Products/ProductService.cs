using AutoMapper;
using Sample.Application.Exceptions;
using Sample.Application.Services.Categories;
using Sample.Core.Entities;
using Sample.DataAccess.Repositories.Categories;
using Sample.DataAccess.Repositories.Products;
using Sample.DataAccess.Repositories.ProductVariants;
using Sample.Shared.Dtos.AttributeProducts;
using Sample.Shared.Dtos.Attributes;
using Sample.Shared.Dtos.Categories;
using Sample.Shared.Dtos.Products;
using Sample.Shared.Dtos.ProductVariants;
using Sample.Shared.Extensions;
using Sample.Shared.SeedWorks;

namespace Sample.Application.Services.Products
{
    public class ProductService : IProductService
    {
        private readonly IProductVariantRepository _productVariantRepository;
        private readonly ICategoryRepository _categoryRepository;
        private readonly IProductRepository _productRepository;
        private readonly IMapper _mapper;
        public ProductService(
            IProductRepository productRepository, 
            IMapper mapper,
            IProductVariantRepository productVariantRepository,
            ICategoryRepository categoryRepository)
        {
            _productRepository = productRepository;
            _mapper = mapper;
            _productVariantRepository = productVariantRepository;
            _categoryRepository = categoryRepository; 
        }
        public ApiResult<CreateProductDto> Create(CreateProductDto createProduct)
        {
            var valid = createProduct.CheckValidation<CreateProductDto>();
            if (valid.IsSuccess == false)
            {
                return new ApiErrorResult<CreateProductDto>(false, 400, valid.Message);
            }
            var product = _mapper.Map<Product>(createProduct);
            _productRepository.Add(product);
            return new ApiSuccessResult<CreateProductDto>(true, "Thêm mới thành công", 200, createProduct);
            
        }

        public ApiResult<CreateProductMappingAttributeDto> CreateMappingAttribute(CreateProductMappingAttributeDto createProductMappingAttributeDto)
        {
            var valid = createProductMappingAttributeDto.CheckValidation<CreateProductMappingAttributeDto>();
            if (valid.IsSuccess == false)
            {
                return new ApiErrorResult<CreateProductMappingAttributeDto>(false, 400, valid.Message);
            }
            var productVariant = _mapper.Map<ProductVariant>(createProductMappingAttributeDto);
            _productVariantRepository.Add(productVariant);
            return new ApiSuccessResult<CreateProductMappingAttributeDto>(true, "Thêm mới thành công", 200, createProductMappingAttributeDto);
        }

        public ApiResult Delete(Guid id)
        {
            var product = _productRepository.FindById(id);
            if (product == null)
            {
                throw new BadRequestException("Sản phẩm không tồn tại");
            }
            _productRepository.Remove(product);
            return new ApiResult(true, "Xóa thành công", 200);
        }

        public ProductDto Get(Guid id)
        {
            var product = _productRepository
                .FindAll(x => x.ProductVariant, y => y.Attribute, z => z.Category)
                .Select(x => new ProductDto()
                {
                    Id = x.Id,
                    CreatedDate = x.CreatedDate,
                    IsDelete = x.IsDelete,
                    Name = x.Name,
                    LastModifiedDate = x.LastModifiedDate,
                    Attributes =
                        x.Attribute
                        .Select(attr => new AttributeDto()
                        {
                            Id = attr.Id,
                            IsDelete = attr.IsDelete,
                            CreatedDate = attr.CreatedDate,
                            LastModifiedDate = attr.LastModifiedDate,
                            Name = attr.Name,
                            AttributeProductDtos = _mapper.Map<List<AttributeProductDto>>(attr.AttributeProduct.ToList())
                        }).ToList(),
                    ProductVariants = _mapper.Map<List<ProductVariantDto>>(x.ProductVariant.ToList()),
                    CategoryDto = _mapper.Map<CategoryDto>(x.Category)
                }).FirstOrDefault();
            if (product == null)
            {
                throw new BadRequestException("Sản phẩm không tồn tại");
            }
            return _mapper.Map<ProductDto>(product);
        }

        public List<ProductDto> GetAll()
        {
            var products = _productRepository
                .FindAll(x => x.ProductVariant, y => y.Attribute, z => z.Category)
                .Select(x => new ProductDto()
                {
                    Id = x.Id,
                    CreatedDate = x.CreatedDate,
                    IsDelete = x.IsDelete,
                    Name = x.Name,
                    LastModifiedDate = x.LastModifiedDate,
                    Attributes = 
                        x.Attribute
                        .Select(attr => new AttributeDto()
                        {
                            Id = attr.Id,
                            IsDelete = attr.IsDelete,
                            CreatedDate = attr.CreatedDate,
                            LastModifiedDate = attr.LastModifiedDate,
                            Name = attr.Name,
                            AttributeProductDtos = _mapper.Map<List<AttributeProductDto>>(attr.AttributeProduct.ToList())
                        }).ToList(),
                    ProductVariants = _mapper.Map<List<ProductVariantDto>>(x.ProductVariant.ToList()),
                    CategoryDto = _mapper.Map<CategoryDto>(x.Category)

                });
            return products.ToList();
        }
        public PagingList<ProductDto> GetPaging(PagingParamesters pagingParamesters)
        {
            var products = _productRepository
                .FindAll(x => x.ProductVariant, y => y.Attribute, z => z.Category)
                .Select(x => new ProductDto()
                {
                    Id = x.Id,
                    CreatedDate = x.CreatedDate,
                    IsDelete = x.IsDelete,
                    Name = x.Name,
                    LastModifiedDate = x.LastModifiedDate,
                    Attributes =
                        x.Attribute
                        .Select(attr => new AttributeDto()
                        {
                            Id = attr.Id,
                            IsDelete = attr.IsDelete,
                            CreatedDate = attr.CreatedDate,
                            LastModifiedDate = attr.LastModifiedDate,
                            Name = attr.Name,
                            AttributeProductDtos = _mapper.Map<List<AttributeProductDto>>(attr.AttributeProduct.ToList())
                        }).ToList(),
                    ProductVariants = _mapper.Map<List<ProductVariantDto>>(x.ProductVariant.ToList()),
                    CategoryDto = _mapper.Map<CategoryDto>(x.Category)

                });
            var productCount = products.Count();
            var productPaing = products.Skip((pagingParamesters.PageNumber - 1) * pagingParamesters.PagingSize).Take(pagingParamesters.PagingSize).ToList();
            return new PagingList<ProductDto>(productPaing, pagingParamesters.PagingSize, pagingParamesters.PageNumber, productCount, productCount / pagingParamesters.PagingSize);
        }

        public ApiResult<UpdateProductDto> Update(UpdateProductDto product)
        {
            var isValid = product.CheckValidation();
            var mapperProduct = _mapper.Map<Product>(product);
            if (isValid.IsSuccess == false)
            {
                return new ApiErrorResult<UpdateProductDto>(false, 400, isValid.Message);
            }
            _productRepository.Update(mapperProduct);
            return new ApiResult<UpdateProductDto>(true, "Cập nhật thành công", 200, product);
        }

        public ApiResult<ProductDto> Update(Guid id)
        {
            var product = _productRepository.FindById(id);
            if (product == null)
            {
                throw new BadRequestException("Sản phẩm không tồn tại");
            }
            _productRepository.Update(product);
            return new ApiResult<ProductDto>(true , "Cập nhật thành công", 200, _mapper.Map<ProductDto>(product)); 
        }
    }
}

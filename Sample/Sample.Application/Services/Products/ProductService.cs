using AutoMapper;
using Sample.Application.Exceptions;
using Sample.Core.Entities;
using Sample.DataAccess.Repositories.Products;
using Sample.Shared.Dtos.Products;
<<<<<<< HEAD
using Sample.Shared.Dtos.ProductVariants;
using Sample.Shared.Dtos.UploadFiles;
=======
>>>>>>> parent of acb1289 (update)
using Sample.Shared.Extensions;
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
            var valid = createProduct.CheckValidation<CreateProductDto>();
            if (valid.IsSuccess == false)
            {
                return new ApiErrorResult<ProductReponse>(false, 400, valid.Message);
            }
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
<<<<<<< HEAD
            var product = _productRepository
                .FindAll(x => x.ProductVariant, y => y.Attribute, z => z.Category,x => x.UploadFile)
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
                    CategoryDto = _mapper.Map<CategoryDto>(x.Category),
                    FileDtos = _mapper.Map<List<FileDto>>(x.UploadFile)
                }).FirstOrDefault();
            if (product == null)
            {
                throw new BadRequestException("Sản phẩm không tồn tại");
            }
            return _mapper.Map<ProductDto>(product);
=======
            throw new NotImplementedException();
>>>>>>> parent of acb1289 (update)
        }

        public ApiResult<ProductReponse> Update(CreateProductDto product)
        {
<<<<<<< HEAD
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

        public List<GetHomeProductCategoryDto> GetHomeProductCategory()
        {
            var products = _categoryRepository
                .FindAll(x => x.Products)
                .Select(z => new GetHomeProductCategoryDto()
                {
                    CategoryName = z.Name,
                    productDtos = z.Products.Select(x => new ProductHomeDto()
                    {
                        Name = x.Name,  
                        ProductVariants = _mapper.Map<List<ProductVariantDto>>(x.ProductVariant.ToList()) 
                    }).Take(5).ToList()
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
=======
            throw new NotImplementedException();
>>>>>>> parent of acb1289 (update)
        }

        public ApiResult<ProductReponse> Update(Guid id)
        {
            throw new NotImplementedException();
        }
    }
}

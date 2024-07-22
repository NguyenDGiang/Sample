using AutoMapper;
using Sample.Application.MappingProfiles;
using Sample.Core.Entities;
using Sample.DataAccess.Repositories.Categories;
using Sample.Shared.Dtos.Categories;
using Sample.Shared.Extensions;
using Sample.Shared.SeedWorks;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Sample.Application.Services.Categories
{
    public class CategoryService : ICategoryService
    {
        private readonly ICategoryRepository _categoryRepository;
        private readonly IMapper _mapper;
        public CategoryService(ICategoryRepository categoryRepository, IMapper mapper)
        {
            _categoryRepository = categoryRepository;
            _mapper = mapper;
        }

        public ApiResult<UpdateCategoryDto> Create(UpdateCategoryDto categoryDto)
        {
            var valid = categoryDto.CheckValidation<UpdateCategoryDto>();
            if (valid.IsSuccess == false)
            {
                return new ApiErrorResult<UpdateCategoryDto>(false, 400, valid.Message);
            }
            var category = _mapper.Map<Category>(categoryDto);
            _categoryRepository.Add(category);
            return new ApiSuccessResult<UpdateCategoryDto>(true, "Thêm mới thành công", 200, null);
        }

        public ApiResult<Category> Delete(int Id)
        {
            try
            {
                _categoryRepository.BeginTransactionAsync();
                Category category = _categoryRepository.FindById(Id);
                Category categoryChildren = _categoryRepository.FindSingle(x => x.ParentId == Id);
                if (category == null)
                {
                    return new ApiErrorResult<Category>(false, 404, "Xóa Lỗi");
                }
                _categoryRepository.Remove(category);
                _categoryRepository.Remove(categoryChildren);
                _categoryRepository.EndTransactionAsync();
                return new ApiSuccessResult<Category>(true, 200, "Xóa Thành Công");
            }
            catch (Exception ex)
            {
                _categoryRepository.RollbackTransactionAsync();
                return new ApiErrorResult<Category>(false, 500, "Lỗi Khi Xóa");
            }
        }

        public List<CategoryReponse> GetAll()
        {
            List<Category> categories = _categoryRepository.FindAll().ToList();
            return GetReCursive(_mapper.Map< List<Category>, List<CategoryReponse>>(categories),0);
        }
        public List<CategoryReponse> GetReCursive(List<CategoryReponse> categories, int Id)
        {
            List<CategoryReponse> result = new List<CategoryReponse>();
            foreach (var item in categories.Where(x=> Id == 0 ? x.ParentId == 0: x.ParentId == Id))
            {
                CategoryReponse category = new CategoryReponse();
                category.Id = item.Id;
                category.Name = item.Name;  
                category.ParentId = item.ParentId;
                category.CategoryChildren =  GetReCursive(categories.ToList(),item.Id);
                result.Add(category);
               
            }
            return result;
        }

        public ApiResult<UpdateCategoryDto> Update(UpdateCategoryDto categoryDto)
        {
            var valid = categoryDto.CheckValidation<UpdateCategoryDto>();
            if (valid.IsSuccess == false)
            {
                return new ApiErrorResult<UpdateCategoryDto>(false, 400, valid.Message);
            }
            var category = _mapper.Map<Category>(categoryDto);
            _categoryRepository.Update(category);
            return new ApiSuccessResult<UpdateCategoryDto>(true, "Thêm mới thành công", 200, null);
        }


    }
}

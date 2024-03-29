﻿using Sample.Core.Entities;
using Sample.Shared.Dtos.Categories;
using Sample.Shared.SeedWorks;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Sample.Application.Services.Categories
{
    public interface ICategoryService
    {
        public CategoryDto GetCategoriesReCursive(Category category);
        List<CategoryDto> GetAll();
        PagingList<CategoryDto> GetPaging(PagingParamesters paingParamesters);
        ApiResult<UpdateCategoryDto> Create(UpdateCategoryDto categoryDto);
        ApiResult<UpdateCategoryDto> Update(UpdateCategoryDto categoryDto);
        ApiResult<Category> Delete(int Id);
    }
}

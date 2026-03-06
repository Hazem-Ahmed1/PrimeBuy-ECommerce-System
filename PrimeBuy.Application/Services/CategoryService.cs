using PrimeBuy.Application.Interfaces;
using PrimeBuy.Application.Interfaces.Repositories;
using PrimeBuy.Domain.Models;
using System;
using System.Collections.Generic;
using System.Text;

namespace PrimeBuy.Application.Services
{
    public class CategoryService : ICategoryService
    {
        private readonly ICategoryRepository categoryRepository;
        public CategoryService(ICategoryRepository categoryRepository)
        {
            this.categoryRepository = categoryRepository;
        }
        public async Task<IEnumerable<Category>> getAllSubCategoriesAsync()
        {
            var cat = await categoryRepository.GetAllAsync();
            var filtered = cat.Where(item => item.ParentCategoryId != null);
            return filtered;
        }
        public async Task<IEnumerable<Category>> getAllParentCategoriesAsync()
        {
            var cat = await categoryRepository.GetAllAsync();
            var filtered = cat.Where(item => item.ParentCategoryId == null);
            return filtered;
        }



    }
}

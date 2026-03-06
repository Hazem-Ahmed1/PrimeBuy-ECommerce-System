using PrimeBuy.Domain.Models;
using System;
using System.Collections.Generic;
using System.Text;

namespace PrimeBuy.Application.Interfaces
{
    public interface ICategoryService
    {
        public Task<IEnumerable<Category>> getAllSubCategoriesAsync();
        public Task<IEnumerable<Category>> getAllParentCategoriesAsync();


    }
}

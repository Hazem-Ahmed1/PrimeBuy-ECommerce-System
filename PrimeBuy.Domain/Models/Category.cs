using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Text;

namespace PrimeBuy.Domain.Models
{
    public class Category
    {
        public int Id { get; set; }
        [MaxLength(100)]
        public string? CategoryImage { get; set; }

        [Required(ErrorMessage = "Category name is required")]
        [MaxLength(200)]
        public string? Name { get; set; }

        [ForeignKey(nameof(ParentCategory))]
        public int? ParentCategoryId { get; set; }
        public Category ParentCategory { get; set; }
        public ICollection<Category> ChildCategories { get; set; } = new HashSet<Category>();
        public ICollection<Product> Products { get; set; } = new HashSet<Product>();
        public Category() { }
        public Category(string name,int? parentCategoryId)
        {
            Name = name;
            ParentCategoryId = parentCategoryId;
        }


    }   
}

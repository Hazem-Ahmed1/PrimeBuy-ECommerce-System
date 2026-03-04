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
        [Required]
        [MaxLength(100)]
        public string CategoryImage { get; set; }
        public string Name { get; set; }

        [ForeignKey(nameof(ParentCategory))]
        public int? ParentCategoryId { get; set; }
        public Category ParentCategory { get; set; }
        public ICollection<Category> ChildCategories { get; set; } = new HashSet<Category>();
        public ICollection<Product> Products { get; set; } = new HashSet<Product>();
        private Category() { }
        public Category(string name,int? parentCategoryId)
        {
            Name = name;
            ParentCategoryId = parentCategoryId;
        }


    }   
}

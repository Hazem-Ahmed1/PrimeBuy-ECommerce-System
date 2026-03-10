using PrimeBuy.Domain.Models;

namespace PrimeBuy.Web.ViewModels
{
    public class HomeVM
    {
        public IEnumerable<Product> Products { get; set; } = new List<Product>();

        public IEnumerable<Product> HighestRateProducts { get; set; } = new List<Product>();

        public IEnumerable<Product> BestSales { get; set; } = new List<Product>();

        public IEnumerable<Category> ParentCategories { get; set; } = new List<Category>();
    }
}

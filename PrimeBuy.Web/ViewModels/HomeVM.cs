using PrimeBuy.Domain.Models;

namespace PrimeBuy.Web.ViewModels
{
    public class HomeVM
    {
        public IEnumerable<Product> Products { get; set; }

        public IEnumerable<Product> HighestRateProducts { get; set; }

        public IEnumerable<Product> BestSales { get; set; }

        public IEnumerable<Category> ParentCategories { get; set; }
    }
}

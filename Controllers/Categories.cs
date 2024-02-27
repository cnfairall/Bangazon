using Bangazon.Models;

namespace Bangazon.Controllers
{
    public class Categories
    {
        public static void Map(WebApplication app)
        {
            //get categories
            app.MapGet("/api/categories", (BangazonDbContext db) =>
            {
                return db.Categories;
            });

            //get total for each category
            app.MapGet("/api/categories/totals", (BangazonDbContext db) =>
            {
                List<int> categoryTotals = new List<int>();
                List<Category> categories = db.Categories.ToList();
                foreach (Category category in categories)
                {
                    var categoryTotal = db.Products.Where(p => p.CategoryId == category.Id).Count();
                    categoryTotals.Add(categoryTotal);
                }
                return categoryTotals;
            });

            //get products for each category
            app.MapGet("/api/categories/products", (BangazonDbContext db) =>
            {
                List<Product> productsByCategory = new List<Product>();
                List<Category> categories = db.Categories.ToList();
                foreach (Category category in categories)
                {
                    List<Product> categoryProducts = db.Products
                                                        .Where(p => p.CategoryId == category.Id)
                                                        .Take(3)
                                                        .ToList();
                    productsByCategory.AddRange(categoryProducts);
                }
                return productsByCategory;
            });
        }
    }
}

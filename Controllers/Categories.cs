using Bangazon.Models;
using Microsoft.EntityFrameworkCore;

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

            //get 3 products for a category
            app.MapGet("/api/{categoryId}/products", (BangazonDbContext db, int categoryId) =>
            {
                List<Product> categoryProducts = db.Products
                                                    .Include(p => p.Seller)
                                                   .Where(p => p.CategoryId == categoryId)
                                                   .Take(3)
                                                   .ToList();
                return categoryProducts;
            });
        }
    }
}

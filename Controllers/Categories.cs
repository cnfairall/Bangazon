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
        }
    }
}

using Bangazon.Dtos;
using Bangazon.Models;
using Microsoft.EntityFrameworkCore;

namespace Bangazon.Controllers
{
    public class Products
    {
        public static void Map(WebApplication app)
        {
            //add product to cart
            app.MapPatch("/api/order/add", (BangazonDbContext db, AddToCartDto orderProduct) =>
            {
                Order orderToUpdate = db.Orders
                .Include(o => o.Products)
                .SingleOrDefault(o => o.Id == orderProduct.OrderId);
                Product productToAdd = db.Products
                .SingleOrDefault(p => p.Id == orderProduct.ProductId);
                if (orderToUpdate == null)
                {
                    return Results.BadRequest("Order not found");
                }
                try
                {
                    orderToUpdate.Products.Add(productToAdd);
                    db.SaveChanges();
                    return Results.NoContent();
                }
                catch (NullReferenceException)
                {
                    return Results.BadRequest("Order not found");
                }
                catch (ArgumentNullException)
                {
                    return Results.BadRequest("Product not found");
                }
            });

            //view product details
            app.MapGet("/api/products/{id}", (BangazonDbContext db, int id) =>
            {
                Product product = db.Products
                .Include(p => p.Seller)
                .SingleOrDefault(p => p.Id == id);
                if (product == null)
                {
                    return Results.NotFound();
                }
                return Results.Ok(product);

            });

            //see newest products
            app.MapGet("/api/products/latest", (BangazonDbContext db) =>
            {
                return db.Products.OrderByDescending(p => p.DateAdded)
                .Take(20)
                .ToList();
            });

        }
    }
}

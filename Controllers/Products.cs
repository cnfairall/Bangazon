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
            app.MapPatch("/api/cart/add", (BangazonDbContext db, AddToCartDto orderProduct) =>
            {
                Order cart = db.Orders
                                .Include(o => o.Products)
                                .SingleOrDefault(o => o.Id == orderProduct.OrderId && o.Open == true);
                Product productToAdd = db.Products
                                          .SingleOrDefault(p => p.Id == orderProduct.ProductId);
                if (cart == null)
                {
                    return Results.BadRequest("Invalid data submitted");
                }
                try
                {
                    cart.Products.Add(productToAdd);
                    db.SaveChanges();
                    return Results.NoContent();
                }
                catch (ArgumentNullException)
                {
                    return Results.BadRequest("Product not found");
                }
            });

            //remove product from cart
            app.MapPatch("/api/cart/remove", (BangazonDbContext db, DeleteFromCartDto orderProduct) =>
            {
                Order cart = db.Orders
                            .Include(o => o.Products)
                            .SingleOrDefault(o => o.Id == orderProduct.OrderId && o.Open == true);
                if (cart == null)
                {
                    return Results.BadRequest("Invalid data submitted");
                }
                if (cart.Products.Count < 1)
                {
                    return Results.BadRequest("Cart is empty");
                }
                Product productToRemove = cart.Products
                                           .SingleOrDefault(p => p.Id == orderProduct.ProductId);
                if (productToRemove == null)
                {
                    return Results.BadRequest("Product not found in cart");
                }
               
                cart.Products.Remove(productToRemove);
                db.SaveChanges();
                return Results.NoContent();
                
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

            //search products
            app.MapGet("/api/products/search/{query}", (BangazonDbContext db, string query) =>
            {
                List<Product> searchResults = db.Products.Where(p => p.Title.Contains(query)).ToList();
                if (searchResults.Count == 0)
                {
                    return Results.NotFound();
                }
                return Results.Ok(searchResults);
            
            });

        }
    }
}

using Bangazon.Models;
using Microsoft.EntityFrameworkCore;

namespace Bangazon.Controllers
{
    public class Orders
    {
        public static void Map(WebApplication app)
        {
            //open cart (on log in or placing order)
            app.MapPost("/api/orders/new", (BangazonDbContext db, int userId) =>
            {
                Order openOrder = db.Orders.SingleOrDefault(o => o.CustomerId == userId && o.Open == true);
                if (openOrder != null)
                {
                    return Results.BadRequest(openOrder);
                }

                Order cart = new Order();
                cart.CustomerId = userId;
                cart.Open = true;
                db.Orders.Add(cart);
                db.SaveChanges();
                return Results.Created($"/api/{userId}/orders/{cart.Id}", cart);
            });

            //get list of user's orders
            app.MapGet("/api/{userId}/orders", (BangazonDbContext db, int userId) =>
            {
                if (userId != null)
                {
                    List<Order> userOrders = db.Orders.Where(o => o.CustomerId == userId).ToList();
                    return userOrders;

                }
                return null;
            });

            //get order details
            app.MapGet("/api/orders/{id}", (BangazonDbContext db, int id) =>
            {
                if (id != null)
                {
                    return db.Orders
                    .Include(o => o.Products)
                    .ThenInclude(p => p.Seller)
                    .SingleOrDefault(o => o.Id == id);
                }
                return null;
            });
        }
    }
}

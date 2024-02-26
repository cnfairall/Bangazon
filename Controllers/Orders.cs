using Bangazon.Dtos;
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

            //get cart
            app.MapGet("/api/{userId}/cart", (BangazonDbContext db, int userId) =>
            {
                Order cart = db.Orders
                                .Include(o => o.Products)
                                .SingleOrDefault(o => o.CustomerId == userId && o.Open == true);
                if (cart != null)
                {
                    return cart;
                }
                return null;
            });

            //place order
            app.MapPatch("/api/cart/close", (BangazonDbContext db, CloseCartDto dto) =>
            {
                Order cart = db.Orders
                                .Include(o => o.Products)
                                .SingleOrDefault(o => o.Id == dto.OrderId && o.Open == true);
                if (cart == null )
                {
                    return Results.BadRequest("Cart not found");
                }
                if (cart.Products.Count < 1)
                {
                    return Results.BadRequest("Cart has no products");
                }
                cart.Open = false;
                cart.DatePlaced = DateTime.Now;
                cart.PaymentTypeId = dto.PaymentTypeId;
                db.SaveChanges();
                return Results.Ok(cart);
            });

            //get single order details (in history)
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

            //get order history (list)
            app.MapGet("/api/{userId}/history", (BangazonDbContext db, int userId) =>
            {
                List<Order> orderHistory = db.Orders
                    .Where(o => o.CustomerId == userId && o.Open == false)
                    .ToList();
                if (userId == null)
                {
                    return Results.BadRequest();
                }
                return Results.Ok(orderHistory);
            });


            //get order history with products
            app.MapGet("/api/{userId}/orders", (BangazonDbContext db, int userId) =>
            {
                List<Order> orderHistory = db.Orders
                    .Include(o => o.Products)
                    .Where(o => o.CustomerId == userId && o.Open == false)
                    .ToList();
                if (userId == null)
                {
                    return Results.BadRequest();
                }
                return Results.Ok(orderHistory);
            });
        }
    }
}

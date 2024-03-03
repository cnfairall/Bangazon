using Bangazon.Dtos;
using Bangazon.Models;
using Microsoft.EntityFrameworkCore;
using System.Data.SqlTypes;
using System.Security.Cryptography.X509Certificates;

namespace Bangazon.Controllers
{
    public class Orders
    {
        public static void Map(WebApplication app)
        {
            //check/create cart
            app.MapGet("/api/{userId}/cart/open", (BangazonDbContext db, int userId) =>
            {
                Order cart = db.Orders
                                .Include(o => o.Products)
                                .SingleOrDefault(o => o.CustomerId == userId && o.Open == true);
                if (cart != null)
                {
                    return Results.Ok("Cart exists");
                } else
                {

                Order newCart = new Order();
                newCart.CustomerId = userId;
                newCart.Open = true;
                db.Orders.Add(newCart);
                db.SaveChanges();
                return Results.Ok(newCart);
                }
            });

            //get cart
            app.MapGet("/api/{userId}/cart", (BangazonDbContext db, int userId) =>
            {
                Order cart = db.Orders
                                .Include(o => o.Products)
                                .SingleOrDefault(o => o.CustomerId == userId && o.Open == true);
                if (cart != null)
                {
                    return Results.Ok(cart);
                }
                else
                {
                    Order newCart = new Order();
                    newCart.CustomerId = userId;
                    newCart.Open = true;
                    db.Orders.Add(newCart);
                    db.SaveChanges();
                    return Results.Ok(newCart);
                }
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

            //get seller's orders with customers
            app.MapGet("/api/{userId}/dashboard/customers", (BangazonDbContext db, int userId) =>
            {
                if (userId != null)
                {
                    List<Order> sellerOrders = db.Orders
                                                 .Include(o => o.Customer)
                                                 .Where(o => o.Products.Any(p => p.SellerId == userId) && o.Open == false).ToList();
                    if (sellerOrders == null)
                    {
                        return Results.NotFound("No orders found");
                    }
                    return Results.Ok(sellerOrders);
                }
                return Results.BadRequest("Invalid data submitted");
            });

            //get seller's orders with products
            app.MapGet("/api/{userId}/dashboard/orders", (BangazonDbContext db, int userId) =>
            {
                if (userId != null)
                {
                    List<Order> sellerOrders = db.Orders
                                                 .Include(o => o.Products)
                                                 .Where(o => o.Products.Any(p => p.SellerId == userId) && o.Open == false).ToList();
                    if (sellerOrders == null)
                    {
                        return Results.NotFound("No orders found");
                    }
                    return Results.Ok(sellerOrders);
                }
                return Results.BadRequest("Invalid data submitted");
            });

            //get dashboard stats
            app.MapGet("/api/{userId}/dashboard/total", (BangazonDbContext db, int userId) =>
            {
                if (userId != null)
                {
                    List<Order> sales = db.Orders
                                          .Include(o => o.Products)
                                          .Where(o => o.Products.Any(p => p.SellerId == userId) && o.Open == false).ToList();
                    Decimal totalSales = 0;
                    int productsSold = 0;

                    if (sales.Count < 1)
                    {
                        return Results.NotFound("No orders found");
                    }

                    foreach (Order sale in sales)
                    {
                        var productTotal = sale.Products.Sum(p => p.PricePer);
                        int products = sale.Products.Count;
                        totalSales += productTotal;
                        productsSold += products;
                    }

                    var averagePerItem = totalSales / productsSold;

                    List<Order> salesThisMonth = db.Orders
                                                   .Include(o => o.Products)
                                                   .Where(o =>
                                                   o.DatePlaced > DateTime.Today.AddDays(-30) &&
                                                   o.Products.Any(p => p.SellerId == userId) && o.Open == false).ToList();
                    Decimal monthEarnings = 0;
                    foreach (Order sale in salesThisMonth)
                    {
                        var total = sale.Products.Sum(p => p.PricePer);
                        monthEarnings += total;
                    }

                    List<Decimal> sellerStats = [ totalSales, averagePerItem, monthEarnings ];
                    
                    return Results.Ok(sellerStats);

                }
           
                return Results.BadRequest("Invalid data submitted");
            });
        }
    }
}

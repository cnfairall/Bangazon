﻿using Bangazon.Models;
using Microsoft.EntityFrameworkCore;
using System.Reflection;

namespace Bangazon.Controllers
{
    public class Users
    {
        public static void Map(WebApplication app)
        {
            //add user
            app.MapPost("/api/users/new", (BangazonDbContext db, User user) =>
            {
                db.Users.Add(user);
                db.SaveChanges();
                return Results.Created($"/api/users/{user.Id}", user);
            });

            //get user
            app.MapGet("/api/users/{userId}", (BangazonDbContext db, int userId) => {
                User user = db.Users.SingleOrDefault(u => u.Id == userId);
                if (user == null)
                {
                    return Results.NotFound();
                }
                return Results.Ok(user);
            });

            //delete user
            app.MapDelete("/api/users/{userId}", (BangazonDbContext db, int userId) =>
            {
                User user = db.Users.SingleOrDefault(u => u.Id == userId);
                if (user == null)
                {
                    return Results.NotFound();
                }
                db.Users.Remove(user);
                db.SaveChanges();
                return Results.NoContent();

            });

            //update user
            app.MapPut("/api/users/{id}", (BangazonDbContext db, int id, User user) =>
            {
                User userToUpdate = db.Users.SingleOrDefault(u => u.Id == id);
                if (userToUpdate == null)
                {
                    return Results.NotFound();
                }
                userToUpdate.Username = user.Username;
                userToUpdate.FirstName = user.FirstName;
                userToUpdate.LastName = user.LastName;
                userToUpdate.Email = user.Email;
                userToUpdate.Address = user.Address;
                userToUpdate.ImageUrl = user.ImageUrl;
                userToUpdate.IsSeller = user.IsSeller;

                db.SaveChanges();
                return Results.NoContent();
            });

            //get user's store
            app.MapGet("/api/{userId}/store", (BangazonDbContext db, int userId) =>
            {
                var store = db.Users
                    .Include(u => u.Products)
                    .SingleOrDefault(u => u.Id == userId);
                if (userId == null)
                {
                    return null;
                }
                return store;
               
            });

            //search sellers
            app.MapGet("/api/sellers/search/{query}", (BangazonDbContext db, string query) =>
            {
                List<User> sellers = db.Users.Where(u => u.IsSeller == true).ToList();
                List<User> sellerResults = sellers.Where(u =>
                                                u.FirstName.ToLower().Contains(query) ||
                                                u.LastName.ToLower().Contains(query) ||
                                                u.Email.ToLower().Contains(query) ||
                                                u.Address.ToLower().Contains(query) ||
                                                u.Username.ToLower().Contains(query))
                                                .ToList();
              
                if (sellerResults.Count == 0)
                {
                    return Results.NotFound();
                }
                return Results.Ok(sellerResults);

            });

            //search customers
            app.MapGet("/api/customers/search/{query}", (BangazonDbContext db, string query) =>
            {
                List<User> customers = db.Users.Where(u => u.IsSeller == false).ToList();
                List<User> customerResults = customers.Where(u =>
                                               u.FirstName.ToLower().Contains(query) ||
                                               u.LastName.ToLower().Contains(query) ||
                                               u.Email.ToLower().Contains(query) ||
                                               u.Address.ToLower().Contains(query) ||
                                               u.Username.ToLower().Contains(query))
                                               .ToList();

                if (customerResults.Count == 0)
                {
                    return Results.NotFound();
                }
                return Results.Ok(customerResults);

            });

            //check user
            app.MapPost("/api/checkUser/{uid}", (BangazonDbContext db, string uid) =>
            {
                User checkUser = db.Users.FirstOrDefault(u => u.Uid == uid);
                if (checkUser == null)
                {
                    return Results.NotFound();
                }
                return Results.Ok(checkUser);
            });
        }
    }
}

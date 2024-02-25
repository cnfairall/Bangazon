using Microsoft.EntityFrameworkCore;
using Bangazon.Models;

public class BangazonDbContext : DbContext
{

    public DbSet<User> Users { get; set; }
    public DbSet<Product> Products { get; set; }
    public DbSet<Order> Orders {  get; set; }
    public DbSet<Category> Categories { get; set; }
    public DbSet<PaymentType> PaymentTypes { get; set; }
    public BangazonDbContext(DbContextOptions<BangazonDbContext> context) : base(context)
    {

    }
    protected override void OnModelCreating(ModelBuilder modelBuilder)
    {
        modelBuilder.Entity<User>().HasData(new User[]
        {
        new User {Id = 1, Uid = "Z487K28", Username = "fastestCar", FirstName = "Larry", LastName = "Dingle", Email = "fastcar@yahoo.com", Address = "24 Hollyhock Ln, Atlanta, GA 13024", IsSeller = true, ImageUrl = "https://up.yimg.com/ib/th?id=OIP.IcMrOf627VHm5umBg-NdkQHaMC&%3Bpid=Api&rs=1&c=1&qlt=95&w=76&h=123"},
        new User {Id = 2, Uid = "FQ985B8", Username = "NightMoves81", FirstName = "Denise", LastName = "Arriat", Email = "nightmoves81@gmail.com", Address = "1824A Cypress Circle, Detroit, MI 57351", IsSeller = false, ImageUrl = "https://tse2.mm.bing.net/th?id=OIP.roc7SqiVeXDbnAinXSVdTQHaNK&pid=Api&P=0&h=220"},
        new User {Id = 3, Uid = "Z487K28", Username = "LilyRose3", FirstName = "Sheryl", LastName = "Barnes", Email = "lilyrose@yahoo.com", Address = "7 Moonlight Way, Miami, FL 92118", IsSeller = true, ImageUrl = "https://tse2.mm.bing.net/th?id=OIP.vahulDgxNXU-mGHiUzFbLwHaLH&pid=Api&P=0&h=220"},
       
        });

        modelBuilder.Entity<Product>().HasData(new Product[]
        {
        new Product {Id = 1, Title = "Bone Boomerang", Description = "Always comes back!", CategoryId = 1, SellerId = 1, DateAdded = new DateTime(2024, 2, 14), PricePer = 12.00M, QuantityAvail = 15, ImageUrl = "https://tse1.mm.bing.net/th?id=OIP.HFDa4OD0-IeYTX5t5CB1FgHaGq&pid=Api&P=0&h=220"},
        new Product {Id = 2, Title = "Wedding gown", Description = "Not cursed!", CategoryId = 2, SellerId = 2, DateAdded = new DateTime(2024, 1, 28), PricePer = 120.00M, QuantityAvail = 1, ImageUrl = "https://sp.yimg.com/ib/th?id=OPHS.0VTDiWr0%2fU%2fVFw474C474&o=5&pid=21.1&w=160&h=105"},
        new Product {Id = 3, Title = "Prepper Bucket", Description = "Everything you need", CategoryId = 3, SellerId = 1, DateAdded = new DateTime(2024, 2, 18), PricePer = 60.00M, QuantityAvail = 6, ImageUrl = "https://sp.yimg.com/ib/th?id=OPHS.BHEw0gGLElfx9A474C474&o=5&pid=21.1&w=160&h=105"},
        new Product {Id = 4, Title = "The Memoir Book", Description = "very long", CategoryId = 4, SellerId = 2, DateAdded = new DateTime(2023, 12, 18), PricePer = 8.00M, QuantityAvail = 2, ImageUrl = "https://tse2.mm.bing.net/th?id=OIP.UlJzwVqHm_CbLNAdaKcKNAHaLH&pid=Api&P=0&h=220"},
        new Product {Id = 5, Title = "Cowgirl Hat", Description = "Nashville classic", CategoryId = 2, SellerId = 2, DateAdded = new DateTime(2024, 2, 22), PricePer = 12.00M, QuantityAvail = 20, ImageUrl = "https://tse2.mm.bing.net/th?id=OIP.UlJzwVqHm_CbLNAdaKcKNAHaLH&pid=Api&P=0&h=220"}

        });

        modelBuilder.Entity<Category>().HasData(new Category[]
        {
        new Category {Id = 1, Name = "Sporting Goods"},
        new Category {Id = 2, Name = "Clothing"},
        new Category {Id = 3, Name = "Dry Goods"},
        new Category {Id = 4, Name = "Books" },
        new Category {Id = 5, Name = "Automotive"}
        });

        modelBuilder.Entity<Order>().HasData(new Order[]
        {
        new Order {Id = 1, CustomerId = 2, Open = true},
        new Order {Id = 2, CustomerId = 3, Open = false, PaymentTypeId = 1, DatePlaced = new DateTime(2024, 1, 15)},
        new Order {Id = 3, CustomerId = 1, Open = false, PaymentTypeId = 2, DatePlaced = new DateTime(2023, 12, 28)},
        new Order {Id = 4, CustomerId = 3, Open = true}

        });

        modelBuilder.Entity<PaymentType>().HasData(new PaymentType[]
        {
        new PaymentType {Id = 1, Name = "Debit Card"},
        new PaymentType {Id = 2, Name = "Credit Card"},
        new PaymentType {Id = 3, Name = "PayPal"}
        });
    }
}